using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
       
        public UsersController(IUserRepository userRepository,IMapper mapper,ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(_mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserDTO>>(users));
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if(user is null) 
            {
                Log.Information("User not found !"); _logger.LogInformation("User not found !");
                return NotFound();
            }

            return Ok(_mapper.Map<User, UserDTO>(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(int id, [FromBody]User user) 
        {
            if(user == null){
                Log.Information("User not found !"); _logger.LogInformation("User not found !");
                return NotFound();
            }
            _userRepository.Edit(user);
            await _userRepository.SaveAsync();

            var updatedUser = await _userRepository.GetUserById(id);
            Log.Information("Successfully updated !"); _logger.LogInformation("Successfully updated !");

            return Ok(_mapper.Map<User, UserDTO>(updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null){
                Log.Information("User not found !"); _logger.LogInformation("User not found !");
                return NotFound();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
            return Ok(_mapper.Map<User, UserDTO>(user));
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDTO>> Create(User user)
        {
            if(user == null){
                Log.Information("User not created ! Check all fields !");  
                return NotFound();
            }
            _userRepository.Add(user);
            await _userRepository.SaveAsync();
            Log.Information("Successfully created");  

            return Ok(_mapper.Map<User, UserDTO>(user)); 
        }
    }
}