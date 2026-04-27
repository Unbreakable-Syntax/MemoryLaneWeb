using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckPatient(id);
            if (result == null) return NotFound(new { success = false, message = "Patient not found" });
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Patients patient)
        {
            await _service.AddPatient(patient);
            return Ok("Patient added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeletePatient(id);
            if (!result) return NotFound("Patient not found");
            return Ok("Patient deleted");
        }
    }
}
