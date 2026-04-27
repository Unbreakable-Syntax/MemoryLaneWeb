using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/emergencyalerts")]
    public class EmergencyAlertsController : ControllerBase
    {
        private readonly IEmergencyAlertService _service;

        public EmergencyAlertsController(IEmergencyAlertService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.CheckEmergencyAlert(id);
            if (result == null) return NotFound(new { success = false, message = "Emergency alert not found" });
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EmergencyAlerts alert)
        {
            await _service.AddEmergencyAlert(alert);
            return Ok("Emergency alert added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteEmergencyAlert(id);
            if (!result) return NotFound("Emergency alert not found");
            return Ok("Emergency alert deleted");
        }
    }
}
