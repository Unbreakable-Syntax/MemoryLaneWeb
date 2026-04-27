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
    }
}
