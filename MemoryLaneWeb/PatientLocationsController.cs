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
            var location = await _service.CheckPatientLocation(id);
            if (!location) return NotFound();
            return Ok("Patient location found");
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
            if (!result) return NotFound();
            return Ok("Patient location deleted");
        }
    }
}
