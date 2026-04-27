using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _service;

        public RemindersController(IReminderService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckReminder(id);
            if (result == null) return NotFound(new { success = false, message = "Reminder not found" });
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Reminders reminder)
        {
            await _service.AddReminder(reminder);
            return Ok("Reminder added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteReminder(id);
            if (!result) return NotFound("Reminder not found");
            return Ok("Reminder deleted");
        }
    }
}
