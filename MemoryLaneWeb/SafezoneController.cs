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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckSafezone(id);
            if (result == null) return NotFound("Safezone not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? patientid, string? zonename, bool? isactive, int? createdby)
        {
            var result = await _service.CheckSafezone(patientid, zonename, isactive, createdby);
            if (result == null) return NotFound("Safezone not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? patientid, string? zonename, bool? isactive, int? createdby)
        {
            var result = await _service.CheckSafezones(patientid, zonename, isactive, createdby);
            if (result.Count == 0) return NotFound("Safezone not found");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SafeZones safezone)
        {
            await _service.AddSafezone(safezone);
            return Ok("Safezone added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteSafezone(id);
            if (!result) return NotFound("Safezone not found");
            return Ok("Safezone deleted");
        }
    }
}
