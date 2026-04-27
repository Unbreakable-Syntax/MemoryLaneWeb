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
            if (result == null) return NotFound(new { success = false, message = "Patient location not found" });
            return Ok(new { success = true, data = result });
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
