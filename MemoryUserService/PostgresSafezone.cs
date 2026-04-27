namespace MemoryUserService
{
    public class PostgresSafezone : ISafezoneService
    {
        private readonly AppDbContext _db;

        public PostgresSafezone(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckSafezone(int id)
        {
            var safezone = await _db.SafeZones.FindAsync(id);
            if (safezone == null) return false;
            return true;
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
    }
}
