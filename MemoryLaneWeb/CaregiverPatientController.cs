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
            if (result == null) return NotFound("Caregiver patient not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? caregiverid, int? patientid, string? emername, string? emerphone)
        {
            var result = await _service.CheckCaregiverPatient(caregiverid, patientid, emername, emerphone);
            if (result == null) return NotFound("Caregiver patient not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? caregiverid, int? patientid, string? emername, string? emerphone)
        {
            var result = await _service.CheckCaregiverPatients(caregiverid, patientid, emername, emerphone);
            if (result.Count == 0) return NotFound("Caregiver patient not found");
            return Ok(result);
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