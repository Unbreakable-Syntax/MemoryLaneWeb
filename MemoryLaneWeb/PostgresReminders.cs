using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresReminders : IReminderService
    {
        private readonly AppDbContext _db;

        public PostgresReminders(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Reminders>> FindReminders(int? reminderID, int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt)
        {
            var query = _db.Reminders.AsQueryable();
            if (reminderID.HasValue)
                query = query.Where(u => u.ReminderID == reminderID.Value);
            if (patientID.HasValue)
                query = query.Where(u => u.PatientID == patientID.Value);
            if (!string.IsNullOrEmpty(title))
                query = query.Where(u => u.Title == title);
            if (!string.IsNullOrEmpty(desc))
                query = query.Where(u => u.Description == desc);
            if (reminderType.HasValue)
                query = query.Where(u => u.ReminderType == reminderType.Value);
            if (remindAt.HasValue)
                query = query.Where(u => u.RemindAt >= remindAt.Value && u.RemindAt < remindAt.Value.AddSeconds(1));

            var reminders = await query.ToListAsync();

            return reminders;
        }


        public async Task<Reminders?> CheckReminder(int id)
        {
            var reminder = await _db.Reminders.FindAsync(id);
            if (reminder == null) return null;
            return reminder;
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
