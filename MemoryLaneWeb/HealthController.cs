using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/")]
    public class HealthController : ControllerBase
    {

        [HttpGet("health")]
        public async Task<IActionResult> Get()
        {
            return Ok("Server active!");
        }
    }
}