using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/caregiverpatients")]
    public class CaregiverPatientController : ControllerBase
    {
        private readonly ICaregiverPatientService _service;

        public CaregiverPatientController(ICaregiverPatientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckCaregiverPatient(id);
            if (result == null) return NotFound(new { success = false, message = "Caregiver patient not found" });
            return Ok(new { success = true, data = result });
        } 

        [HttpPost("add")]
        public async Task<IActionResult> Add(CaregiverPatient patient)
        {
            await _service.AddCaregiverPatient(patient);
            return Ok("Caregiver patient added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCaregiverPatient(id);
            if (!result) return NotFound("Caregiver patient not found");
            return Ok("Caregiver patient deleted");
        }
    }
}