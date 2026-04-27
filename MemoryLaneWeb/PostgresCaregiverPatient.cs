namespace MemoryLaneWeb
{
    public class PostgresCaregiverPatient : ICaregiverPatientService
    {
        private readonly AppDbContext _db;

        public PostgresCaregiverPatient(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckCaregiverPatient(int id)
        {
            var patient = await _db.CaregiverPatient.FindAsync(id);
            if (patient == null) return false;
            return true;
        }

        public async Task AddCaregiverPatient(CaregiverPatient patient)
        {
            _db.CaregiverPatient.Add(patient);
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
    }
}
