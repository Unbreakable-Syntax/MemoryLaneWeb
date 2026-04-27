using Microsoft.AspNetCore.Mvc;

namespace MemoryUserService
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
            var alert = await _service.CheckEmergencyAlert(id);
            if (!alert) return NotFound();
            return Ok("Emergency alert found");
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
            if (!result) return NotFound();
            return Ok("Emergency alert deleted");
        }
    }
}
