using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresCaregiverPatient : ICaregiverPatientService
    {
        private readonly AppDbContext _db;

        public PostgresCaregiverPatient(AppDbContext db)
        {
            _db = db;
        }

        public async Task<CaregiverPatient?> CheckCaregiverPatient(int id)
        {
            var patient = await _db.CaregiverPatient.FindAsync(id);
            if (patient == null) return null;
            return patient;
        }

        public async Task<CaregiverPatient?> CheckCaregiverPatient(int? caregiverid, int? patientid, string? emername, string? emerphone)
        {
            var query = _db.CaregiverPatient.AsQueryable();
            if (caregiverid.HasValue) query = query.Where(u => u.CaregiverID == caregiverid.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (!string.IsNullOrEmpty(emername)) query = query.Where(u => emername.Equals(u.EmergencyContactName));
            if (!string.IsNullOrEmpty(emerphone)) query = query.Where(u => emerphone.Equals(u.EmergencyContactPhone));
            var patient = await query.FirstOrDefaultAsync();
            return patient;
        }

        public async Task<List<CaregiverPatient>> CheckCaregiverPatients(int? caregiverid, int? patientid, string? emername, string? emerphone)
        {
            var query = _db.CaregiverPatient.AsQueryable();
            if (caregiverid.HasValue) query = query.Where(u => u.CaregiverID == caregiverid.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (!string.IsNullOrEmpty(emername)) query = query.Where(u => emername.Equals(u.EmergencyContactName));
            if (!string.IsNullOrEmpty(emerphone)) query = query.Where(u => emerphone.Equals(u.EmergencyContactPhone));
            var patients = await query.ToListAsync();
            return patients;
        }

        public async Task AddCaregiverPatient(CaregiverPatient patient)
        {
            var query = _db.CaregiverPatient.AsQueryable();
            query = query.Where(u => u.PatientID == patient.PatientID || u.CaregiverID == patient.CaregiverID);
            var result = await query.FirstOrDefaultAsync();
            if (result != null)
            {
                result.EmergencyContactName = patient.EmergencyContactName;
                result.EmergencyContactPhone = patient.EmergencyContactPhone;
                result.SafeZoneLatitude = patient.SafeZoneLatitude;
                result.SafeZoneLongitude = patient.SafeZoneLongitude;
                result.SafeZoneRadius = patient.SafeZoneRadius;
            }
            else _db.CaregiverPatient.Add(patient);

            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteCaregiverPatient(int id)
        {
            var patient = await _db.CaregiverPatient.FindAsync(id);
            if (patient == null) return false;
            _db.CaregiverPatient.Remove(patient);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnenrollPatient(int userid)
        {
            var query = _db.CaregiverPatient.AsQueryable();
            query = query.Where(u => u.CaregiverID == userid);
            var result = await query.FirstOrDefaultAsync();
            if (result == null) return false;
            int patientid = result.PatientID;

            await _db.EmergencyAlerts.Where(u => u.PatientID == patientid).ExecuteDeleteAsync();
            await _db.Reminders.Where(u => u.PatientID == patientid).ExecuteDeleteAsync();
            await _db.SafeZones.Where(u => u.PatientID == patientid).ExecuteDeleteAsync();
            await _db.ChatMessages.Where(u => u.PatientID == patientid).ExecuteDeleteAsync();
            await _db.CaregiverPatient.Where(u => u.Id == result.Id).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
