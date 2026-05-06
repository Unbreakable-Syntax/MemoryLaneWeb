using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckPatient(id);
            if (result == null) return NotFound("Patient not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? userid, DateTime? birthdate, Genders? gender, string? medcon, int? age, string? meds, string? allergies)
        {
            var result = await _service.CheckPatient(userid, birthdate, gender, medcon, age, meds, allergies);
            if (result == null) return NotFound("Patient not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? userid, DateTime? birthdate, Genders? gender, string? medcon, int? age, string? meds, string? allergies)
        {
            var result = await _service.CheckPatients(userid, birthdate, gender, medcon, age, meds, allergies);
            if (result.Count == 0) return NotFound("Patient not found");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Patients patient)
        {
            await _service.AddPatient(patient);
            return Ok("Patient added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeletePatient(id);
            if (!result) return NotFound("Patient not found");
            return Ok("Patient deleted");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, int? age, string? medcons, string? meds, string? allergies)
        {
            var result = await _service.UpdatePatient(id, age, medcons, meds, allergies);
            if (!result) return NotFound("Patient not found");
            return Ok("Patient updated");
        }
    }
}
