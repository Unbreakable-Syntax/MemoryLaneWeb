using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresSafezone : ISafezoneService
    {
        private readonly AppDbContext _db;

        public PostgresSafezone(AppDbContext db)
        {
            _db = db;
        }

        public async Task<SafeZones?> CheckSafezone(int id)
        {
            var safezone = await _db.SafeZones.FindAsync(id);
            if (safezone == null) return null;
            return safezone;
        }

        public async Task<SafeZones?> CheckSafezone(int? patientid, string? zonename, bool? isactive, int? createdby)
        {
            var query = _db.SafeZones.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid);
            if (!string.IsNullOrEmpty(zonename)) query = query.Where(u => zonename.Equals(u.ZoneName));
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            if (createdby.HasValue) query = query.Where(u => u.CreatedBy == createdby.Value);

            var safezone = await query.FirstOrDefaultAsync();
            return safezone;
        }

        public async Task<List<SafeZones>> CheckSafezones(int? patientid, string? zonename, bool? isactive, int? createdby)
        {
            var query = _db.SafeZones.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid);
            if (!string.IsNullOrEmpty(zonename)) query = query.Where(u => zonename.Equals(u.ZoneName));
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            if (createdby.HasValue) query = query.Where(u => u.CreatedBy == createdby.Value);

            var safezones = await query.ToListAsync();
            return safezones;
        }

        public async Task AddSafezone(SafeZones safezone)
        {
            _db.SafeZones.Add(safezone);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteSafezone(int id)
        {
            var safezone = await _db.SafeZones.FindAsync(id);
            if (safezone == null) return false;
            _db.SafeZones.Remove(safezone);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkInactive(int id)
        {
            var result = await _db.SafeZones.FindAsync(id);
            if (result == null) return false;
            result.IsActive = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
