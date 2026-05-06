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

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? patientid, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc)
        {
            var result = await _service.CheckReminder(patientid, title, desc, reminderType, remindAt, recurrence, isacknowledged, isactive, orderby, isdesc);
            if (result == null) return NotFound("Reminder not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? patientid, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc)
        {
            var result = await _service.CheckReminders(patientid, title, desc, reminderType, remindAt, recurrence, isacknowledged, isactive, orderby, isdesc);
            if (result.Count == 0) return NotFound("Reminder not found");
            return Ok(result);
        }

        [HttpGet("getalluser/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await _service.GetReminders(id);
            if (result.Count == 0) return NotFound("Reminder not found");
            return Ok(result);
        }

        [HttpGet("getallcaregiver/{id}")]
        public async Task<IActionResult> GetAllCaregiver(int id)
        {
            var result = await _service.GetRemindersCaregiver(id);
            if (result.Count == 0) return NotFound("Reminder not found");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckReminder(id);
            if (result == null) return NotFound("Reminder not found");
            return Ok(result);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive)
        {
            var result = await _service.UpdateReminder(id, title, desc, reminderType, remindAt, recurrence, isacknowledged, isactive);
            if (!result) return NotFound("Reminder not found");
            return Ok("Reminder updated");
        }
    }
}
