namespace MemoryLaneWeb
{
    public class PostgresPatient : IPatientService
    {
        private readonly AppDbContext _db;

        public PostgresPatient(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckPatient(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return false;
            return true;
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
