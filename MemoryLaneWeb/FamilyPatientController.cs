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
