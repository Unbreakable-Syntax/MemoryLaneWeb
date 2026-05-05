using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/patientlocations")]
    public class PatientLocationsController : ControllerBase
    {
        private readonly IPatientLocationService _service;
        public PatientLocationsController(IPatientLocationService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.CheckPatientLocation(id);
            if (result == null) return NotFound("Patient location not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? patientid, GPSSources? source, DateTime? recordedat)
        {
            var result = await _service.CheckPatientLocation(patientid, source, recordedat);
            if (result == null) return NotFound("Patient location not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? patientid, GPSSources? source, DateTime? recordedat)
        {
            var result = await _service.CheckPatientLocations(patientid, source, recordedat);
            if (result.Count == 0) return NotFound("Patient location not found");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PatientLocations location)
        {
            await _service.AddPatientLocation(location);
            return Ok("Patient location added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeletePatientLocation(id);
            if (!result) return NotFound("Patient location not found");
            return Ok("Patient location deleted");
        }
    }
}
