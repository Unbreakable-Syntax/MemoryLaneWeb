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
            var fpatient = await _service.CheckFamilyPatient(id);
            if (!fpatient) return NotFound();
            return Ok("Family patient found");
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
            if (!result) return NotFound();
            return Ok("Family patient deleted");
        }
    }
}
