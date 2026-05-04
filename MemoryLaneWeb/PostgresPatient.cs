using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresPatient : IPatientService
    {
        private readonly AppDbContext _db;

        public PostgresPatient(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> UpdatePatient(int id, int? age, string? medcons, string? meds, string? allergies)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return false;

            // Only update fields that are NOT null
            if (age.HasValue) patient.Age = age.Value;
            if (!string.IsNullOrEmpty(medcons)) patient.MedicalConditions = medcons;
            if (!string.IsNullOrEmpty(meds)) patient.Medications = meds;
            if (!string.IsNullOrEmpty(allergies)) patient.Allergies = allergies;

            patient.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Patients?> CheckPatient(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return null;
            return patient;
        }

        public async Task<Patients?> CheckPatientUserID(int userid)
        {
            var query = _db.Patients.AsQueryable();
            query = query.Where(r => r.UserID == userid);
            var patient = await query.FirstOrDefaultAsync();
            return patient;
        }

        public async Task AddPatient(Patients patient)
        {
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeletePatient(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return false;
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
