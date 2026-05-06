namespace MemoryLaneWeb
{
    public interface IReminderService
    {
        Task<List<Reminders>> CheckReminders(int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc);
        Task<Reminders?> CheckReminder(int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive, string? orderby, bool? isdesc);
        Task<Reminders?> CheckReminder(int id);
        Task<List<Reminders>> GetReminders(int uid);
        Task<List<Reminders>> GetRemindersCaregiver(int cid);
        Task AddReminder(Reminders reminder);
        Task<bool> DeleteReminder(int id);
        Task<bool> UpdateReminder(int id, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt, ReminderOccurence? recurrence, bool? isacknowledged, bool? isactive);
    }
}
