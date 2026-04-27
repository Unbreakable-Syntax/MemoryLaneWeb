using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/safezones")]
    public class SafezoneController : ControllerBase
    {
        private readonly ISafezoneService _service;

        public SafezoneController(ISafezoneService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckSafezone(id);
            if (result == null) return NotFound(new { success = false, message = "Safezone not found" });
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SafeZones safezone)
        {
            await _service.AddSafezone(safezone);
            return Ok("Safezone added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteSafezone(id);
            if (!result) return NotFound("Safezone not found");
            return Ok("Safezone deleted");
        }
    }
}
