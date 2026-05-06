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

        public async Task<PatientLocations?> CheckPatientLocation(int? patientid, GPSSources? source, DateTime? recordedat, string? orderby, bool? isdesc)
        {
            var query = _db.PatientLocations.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (source.HasValue) query = query.Where(u => u.Source == source.Value);
            if (recordedat.HasValue) query = query.Where(u => u.RecordedAt == recordedat.Value);
            if (!string.IsNullOrEmpty(orderby))
            {
                if (isdesc.HasValue && isdesc.Value == false) query = query.OrderByDescending(e => EF.Property<object>(e, orderby));
                else query = query.OrderBy(e => EF.Property<object>(e, orderby));
            }
            var patientloc = await query.FirstOrDefaultAsync();
            return patientloc;
        }

        public async Task<List<PatientLocations>> CheckPatientLocations(int? patientid, GPSSources? source, DateTime? recordedat, string? orderby, bool? isdesc)
        {
            var query = _db.PatientLocations.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (source.HasValue) query = query.Where(u => u.Source == source.Value);
            if (recordedat.HasValue) query = query.Where(u => u.RecordedAt == recordedat.Value);
            if (!string.IsNullOrEmpty(orderby))
            {
                if (isdesc.HasValue && isdesc.Value == false) query = query.OrderByDescending(e => EF.Property<object>(e, orderby));
                else query = query.OrderBy(e => EF.Property<object>(e, orderby));
            }
            var patientlocs = await query.ToListAsync();
            return patientlocs;
        }

        public async Task AddPatientLocation(PatientLocations location)
        {
            var query = _db.PatientLocations.AsQueryable();
            query = query.Where(u => u.PatientID == location.PatientID);
            var result = await query.FirstOrDefaultAsync();
            if (result != null)
            {
                result.Latitude = location.Latitude;
                result.Longitude = location.Longitude;
                result.Altitude = location.Altitude;
                result.AccuracyM = location.AccuracyM;
                result.Source = location.Source;
                result.RecordedAt = DateTime.UtcNow;
            }
            else _db.PatientLocations.Add(location);

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
