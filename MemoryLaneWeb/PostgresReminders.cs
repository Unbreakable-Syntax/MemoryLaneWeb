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

        public async Task<List<Reminders>> CheckReminders(int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc)
        {
            var query = _db.Reminders.AsQueryable();
            if (patientID.HasValue) query = query.Where(u => u.PatientID == patientID.Value);
            if (!string.IsNullOrEmpty(title)) query = query.Where(u => u.Title == title);
            if (!string.IsNullOrEmpty(desc)) query = query.Where(u => u.Description == desc);
            if (reminderType.HasValue) query = query.Where(u => u.ReminderType == reminderType.Value);
            if (remindAt.HasValue) query = query.Where(u => u.RemindAt >= remindAt.Value && u.RemindAt < remindAt.Value.AddSeconds(1));
            if (recurrence.HasValue) query = query.Where(u => u.Recurrences == recurrence.Value);
            if (isacknowledged.HasValue) query = query.Where(u => u.IsAcknowledged == isacknowledged.Value);
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            if (!string.IsNullOrEmpty(orderby))
            {
                if (isdesc.HasValue && isdesc.Value == true) query = query.OrderByDescending(e => EF.Property<object>(e, orderby));
                else query = query.OrderBy(e => EF.Property<object>(e, orderby));
            }

            var reminders = await query.ToListAsync();

            return reminders;
        }

        public async Task<Reminders?> CheckReminder(int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc)
        {
            var query = _db.Reminders.AsQueryable();
            if (patientID.HasValue) query = query.Where(u => u.PatientID == patientID.Value);
            if (!string.IsNullOrEmpty(title)) query = query.Where(u => u.Title == title);
            if (!string.IsNullOrEmpty(desc)) query = query.Where(u => u.Description == desc);
            if (reminderType.HasValue) query = query.Where(u => u.ReminderType == reminderType.Value);
            if (remindAt.HasValue) query = query.Where(u => u.RemindAt >= remindAt.Value && u.RemindAt < remindAt.Value.AddSeconds(1));
            if (recurrence.HasValue) query = query.Where(u => u.Recurrences == recurrence.Value);
            if (isacknowledged.HasValue) query = query.Where(u => u.IsAcknowledged == isacknowledged.Value);
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            if (!string.IsNullOrEmpty(orderby))
            {
                if (isdesc.HasValue && isdesc.Value == true) query = query.OrderByDescending(e => EF.Property<object>(e, orderby));
                else query = query.OrderBy(e => EF.Property<object>(e, orderby));
            }


            var reminder = await query.FirstOrDefaultAsync();

            return reminder;
        }

        public async Task<List<Reminders>> GetReminders(int uid)
        {
            var reminders = await _db.Reminders
            .Join(_db.Patients,
                r => r.PatientID,
                p => p.PatientID,
                (r, p) => new { r, p })
            .Where(x => x.p.UserID == uid
                     && x.r.IsAcknowledged == false
                     && x.r.IsActive == true)
            .OrderBy(x => x.r.RemindAt)
            .Select(x => x.r)
            .ToListAsync();
            return reminders;
        }

        public async Task<List<Reminders>> GetRemindersCaregiver(int cid)
        {
            var reminders = await _db.Reminders
                .Join(_db.CaregiverPatient,
                r => r.PatientID,
                cp => cp.PatientID,
                (r, cp) => new { r, cp })
                .Where(x => x.cp.CaregiverID == cid && x.r.IsAcknowledged == false && x.r.IsActive == true)
                .OrderBy(x => x.r.RemindAt)
                .Select(x => x.r)
                .ToListAsync();

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

        public async Task<bool> UpdateReminder(int id, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive)
        {
            var reminder = await _db.Reminders.FindAsync(id);
            if (reminder == null) return false;

            if (!string.IsNullOrEmpty(title)) reminder.Title = title;
            if (!string.IsNullOrEmpty(desc)) reminder.Description = desc;
            if (reminderType.HasValue) reminder.ReminderType = reminderType.Value;
            if (remindAt.HasValue) reminder.RemindAt = remindAt.Value;
            if (recurrence.HasValue) reminder.Recurrences = recurrence.Value;
            if (isacknowledged.HasValue) reminder.IsAcknowledged = isacknowledged.Value;
            if (isactive.HasValue) reminder.IsActive = isactive.Value;
            reminder.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
