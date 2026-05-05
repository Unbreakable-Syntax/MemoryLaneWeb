using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresPatientLocations : IPatientLocationService
    {
        private readonly AppDbContext _db;

        public PostgresPatientLocations(AppDbContext db)
        {
            _db = db;
        }

        public async Task<PatientLocations?> CheckPatientLocation(long id)
        {
            var location = await _db.PatientLocations.FindAsync(id);
            if (location == null) return null;
            return location;
        }

        public async Task<PatientLocations?> CheckPatientLocation(int? patientid, GPSSources? source, DateTime? recordedat)
        {
            var query = _db.PatientLocations.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (source.HasValue) query = query.Where(u => u.Source == source.Value);
            if (recordedat.HasValue) query = query.Where(u => u.RecordedAt == recordedat.Value);
            var patientloc = await query.FirstOrDefaultAsync();
            return patientloc;
        }

        public async Task<List<PatientLocations>> CheckPatientLocations(int? patientid, GPSSources? source, DateTime? recordedat)
        {
            var query = _db.PatientLocations.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (source.HasValue) query = query.Where(u => u.Source == source.Value);
            if (recordedat.HasValue) query = query.Where(u => u.RecordedAt == recordedat.Value);
            var patientlocs = await query.ToListAsync();
            return patientlocs;
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
