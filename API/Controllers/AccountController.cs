using System.Security.Claims;
using API.DTO;
using API.DTO.Authentication;
using API.Errors;
using Core.Entities;
using Core.Enums.Claims;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Serilog;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public readonly ILogger<User> _logger;
        public readonly IDistributedCache _cache;
        private readonly IUserRepository _userRepository;
        
        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            ITokenService tokenService, 
            ILogger<User> logger,
            IDistributedCache cache,
            IUserRepository userRepository)
        {
            _logger = logger;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _cache = cache;
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<UserLoginDTO>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);
            
             return new UserLoginDTO
             {
                Id = user.Id,
                DisplayName = user.FirstName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
             };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            
            if(user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            
            if(!result.Succeeded)
            {
                Log.Information("Wrong data");
                return Unauthorized(new ApiResponse(401));
            }
            
            var refreshToken = _tokenService.GenerateRefreshToken();
            //redis 
            await _cache.SetStringAsync($"member-{user.Id}", refreshToken);
            return new UserLoginDTO
            {   
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.FirstName,
                Token = await _tokenService.CreateTokenAsync(user),
                RefreshToken = refreshToken
            };
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserLoginDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Gender = "Male",
                Birthday = new DateOnly(),
                Adress = "Grillweg 71",
                Country = "BIH",
                Nationality = "BIH",
                MemberFrom = DateTime.Now,
                Active =1,
                Email = registerDTO.Email  ,
                UserName = registerDTO.Email,
                Phone = "0626731231",
                MarriageStatus ="FK",
                LastActive = DateTime.Now,
                AssociationId = 1
            };
            
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserLoginDTO
            {
                Token = await _tokenService.CreateTokenAsync(user),
                Email = user.UserName
            };
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ActionResult<TokenRequest>> Refresh([FromBody] TokenRequest tokenRequest)
        {
            if (tokenRequest == null) return BadRequest();
            
            if(!string.IsNullOrEmpty(tokenRequest.RefreshToken) && !string.IsNullOrWhiteSpace(tokenRequest.Token))
            {
                var principal = _tokenService.GetClaimsPrincipalFromExpiredToken(tokenRequest.Token);
                var userId = principal.FindFirst(CustomClaims.Id)?.Value;
                var user = await _userRepository.GetUserById(Int32.Parse(userId));
                
                if (user == null) return BadRequest();

                var cacheRefreshToken = await _cache.GetStringAsync($"member-{user.Id}");
               
                if(cacheRefreshToken != tokenRequest.RefreshToken) 
                {
                    return BadRequest();
                }

                var token = _tokenService.CreateTokenAsync(user);
                var refresh = _tokenService.GenerateRefreshToken();
                //remove old refresh token and set new one
                await _cache.RemoveAsync($"member-{user.Id}");
                await _cache.SetStringAsync($"member-{user.Id}", refresh);

                return new TokenRequest() { Token = await token, RefreshToken = refresh };
            }

            return BadRequest();

        }
    }
}