using Microsoft.AspNetCore.Mvc;

namespace MemoryUserService
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
            if (!result) return NotFound();
            return Ok("User found");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Users user)
        {
            await _service.AddUser(user);
            return Ok("User added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUser(id);
            if (!result) return NotFound();
            return Ok("User deleted");
        }
    }
}
