namespace MemoryUserService
{
    public class PostgresReminders : IReminderService
    {
        private readonly AppDbContext _db;

        public PostgresReminders(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckReminder(int id)
        {
            var reminder = await _db.Reminders.FindAsync(id);
            if (reminder == null) return false;
            return true;
        }

        public async Task AddReminder(Reminders reminder)
        {
            _db.Reminders.Add(reminder);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteReminder(int id)
        {
            var reminder = await _db.Reminders.FindAsync(id);
            if (reminder == null) return false;
            _db.Reminders.Remove(reminder);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
