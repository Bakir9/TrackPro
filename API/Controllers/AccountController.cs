using System.Security.Claims;
using API.DTO;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public readonly ILogger<User> _logger;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, ILogger<User> logger)
        {
            _logger = logger;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserLoginDTO>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);
            
             return new UserLoginDTO
             {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
             };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            
            if(user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            
            if(!result.Succeeded)
            {
                Log.Information("Wrong data");
                return  Unauthorized(new ApiResponse(401));
            } 

            return new UserLoginDTO
            {   
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.FirstName,
                Token = _tokenService.CreateToken(user)
            };
        }
       
        [HttpPost("register")]
        public async Task<ActionResult<UserLoginDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Gender = "Male",
                Birthday = new DateOnly(),
                Adress =" Grillweg 71",
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
                Token = _tokenService.CreateToken(user),
                Email = user.UserName
            };
        }
    }
}