using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody]User user) 
        {
            if(user == null){
                return NotFound();
            }
            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            var updatedUser = await _userRepository.GetUserById(id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null){
                return NotFound();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> Create(User user)
        {
            if(user == null){
                return NotFound();
            }

            _userRepository.Create(user);
            await _userRepository.SaveAsync();

            return Ok(user); 
        }
    }
}