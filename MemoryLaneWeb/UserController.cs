using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckUser(id);
            if (result == null) return NotFound("User not found");
            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetEmail(string email)
        {
            var result = await _service.CheckUserEmail(email);
            if (result == null) return NotFound("User not found");
            return Ok("User found");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Users user)
        {
            int id = await _service.AddUser(user);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUser(id);
            if (!result) return NotFound("User not found");
            return Ok("User deleted");
        }
    }
}
