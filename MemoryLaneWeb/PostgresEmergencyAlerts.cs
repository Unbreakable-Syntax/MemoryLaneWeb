using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresEmergencyAlerts : IEmergencyAlertService
    {
        private readonly AppDbContext _db;

        public PostgresEmergencyAlerts(AppDbContext db)
        {
            _db = db;
        }

        public async Task<EmergencyAlerts?> CheckEmergencyAlert(long id)
        {
            var alert = await _db.EmergencyAlerts.FindAsync(id);
            if (alert == null) return null;
            return alert;
        }

        public async Task<EmergencyAlerts?> CheckEmergencyAlert(int? patientid, AlertTypes? alerttype, Severities? severity, bool? isresolved, int? resolvedby, DateTime? resolvedat, DateTime? triggered) 
        {
            var query = _db.EmergencyAlerts.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (alerttype.HasValue) query = query.Where(u => u.AlertType == alerttype.Value);
            if (severity.HasValue) query = query.Where(u => u.Severity == severity.Value);
            if (isresolved.HasValue) query = query.Where(u => u.IsResolved == isresolved.Value);
            if (resolvedby.HasValue) query = query.Where(u => u.ResolvedBy == resolvedby.Value);
            if (resolvedat.HasValue) query = query.Where(u => u.ResolvedAt == resolvedat.Value);
            if (triggered.HasValue) query = query.Where(u => u.TriggeredAt == triggered.Value);

            var alert = await query.FirstOrDefaultAsync();
            return alert;
        }

        public async Task<List<EmergencyAlerts>> CheckEmergencyAlerts(int? patientid, AlertTypes? alerttype, Severities? severity, bool? isresolved, int? resolvedby, DateTime? resolvedat, DateTime? triggered)
        {
            var query = _db.EmergencyAlerts.AsQueryable();
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (alerttype.HasValue) query = query.Where(u => u.AlertType == alerttype.Value);
            if (severity.HasValue) query = query.Where(u => u.Severity == severity.Value);
            if (isresolved.HasValue) query = query.Where(u => u.IsResolved == isresolved.Value);
            if (resolvedby.HasValue) query = query.Where(u => u.ResolvedBy == resolvedby.Value);
            if (resolvedat.HasValue) query = query.Where(u => u.ResolvedAt == resolvedat.Value);
            if (triggered.HasValue) query = query.Where(u => u.TriggeredAt == triggered.Value);

            var alerts = await query.ToListAsync();
            return alerts;
        }

        public async Task AddEmergencyAlert(EmergencyAlerts alert)
        {
            _db.EmergencyAlerts.Add(alert);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmergencyAlert(long id)
        {
            var alert = await _db.EmergencyAlerts.FindAsync(id);
            if (alert == null) return false;
            _db.EmergencyAlerts.Remove(alert);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkResolved(long alertid, int resolvedby)
        {
            var target = await _db.EmergencyAlerts.FindAsync(alertid);
            if (target == null) return false;
            target.ResolvedBy = resolvedby;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
