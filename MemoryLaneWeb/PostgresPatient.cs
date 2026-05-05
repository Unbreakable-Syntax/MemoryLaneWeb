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

        public async Task<Patients?> CheckPatient(int? userid, DateTime? birthdate, Genders? gender, string medcons, int? age, string meds, string allergies)
        {
            var query = _db.Patients.AsQueryable();

            if (userid.HasValue) query = query.Where(u => u.UserID == userid.Value);
            if (birthdate.HasValue) query = query.Where(u => u.Birthdate == birthdate.Value);
            if (gender.HasValue) query = query.Where(u => u.Gender == gender.Value);
            if (!string.IsNullOrEmpty(medcons)) query = query.Where(u => medcons.Equals(u.MedicalConditions));
            if (age.HasValue) query = query.Where(u => u.Age == age.Value);
            if (!string.IsNullOrEmpty(meds)) query = query.Where(u => meds.Equals(u.Medications));
            if (!string.IsNullOrEmpty(allergies)) query = query.Where(u => allergies.Equals(u.Allergies));
            var patient = await query.FirstOrDefaultAsync();

            return patient;
        }

        public async Task<List<Patients>> CheckPatients(int? userid, DateTime? birthdate, Genders? gender, string medcons, int? age, string meds, string allergies)
        {
            var query = _db.Patients.AsQueryable();

            if (userid.HasValue) query = query.Where(u => u.UserID == userid.Value);
            if (birthdate.HasValue) query = query.Where(u => u.Birthdate == birthdate.Value);
            if (gender.HasValue) query = query.Where(u => u.Gender == gender.Value);
            if (!string.IsNullOrEmpty(medcons)) query = query.Where(u => medcons.Equals(u.MedicalConditions));
            if (age.HasValue) query = query.Where(u => u.Age == age.Value);
            if (!string.IsNullOrEmpty(meds)) query = query.Where(u => meds.Equals(u.Medications));
            if (!string.IsNullOrEmpty(allergies)) query = query.Where(u => allergies.Equals(u.Allergies));
            var patients = await query.ToListAsync();

            return patients;
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
