namespace MemoryLaneWeb
{
    public class PostgresPatientLocations : IPatientLocationService
    {
        private readonly AppDbContext _db;

        public PostgresPatientLocations(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckPatientLocation(long id)
        {
            var location = await _db.PatientLocations.FindAsync(id);
            if (location == null) return false;
            return true;
        }

        public async Task AddPatientLocation(PatientLocations location)
        {
            _db.PatientLocations.Add(location);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeletePatientLocation(long id)
        {
            var location = await _db.PatientLocations.FindAsync(id);
            if (location == null) return false;
            _db.PatientLocations.Remove(location);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
