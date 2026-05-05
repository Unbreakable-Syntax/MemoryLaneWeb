using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/familypatients")]
    public class FamilyPatientController : ControllerBase
    {
        private readonly IFamilyPatientService _service;
        public FamilyPatientController(IFamilyPatientService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckFamilyPatient(id);
            if (result == null) return NotFound("Family patient not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? familyid, int? patientid, string? rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat)
        {
            var result = await _service.CheckFamilyPatient(familyid, patientid, rs, canviewloc, canviewalert, assignedat);
            if (result == null) return NotFound("Family patient not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? familyid, int? patientid, string? rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat)
        {
            var result = await _service.CheckFamilyPatients(familyid, patientid, rs, canviewloc, canviewalert, assignedat);
            if (result.Count == 0) return NotFound("Family patient not found");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(FamilyPatient fpatient)
        {
            await _service.AddFamilyPatient(fpatient);
            return Ok("Family patient added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteFamilyPatient(id);
            if (!result) return NotFound("Family patient not found");
            return Ok("Family patient deleted");
        }
    }
}
