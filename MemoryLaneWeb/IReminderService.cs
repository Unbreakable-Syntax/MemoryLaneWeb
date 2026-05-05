namespace MemoryLaneWeb
{
    public interface IReminderService
    {
        Task<List<Reminders>> CheckReminders(int? reminderID, int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt);
        Task<Reminders?> CheckReminder(int? reminderID, int? patientID, string? title, string? desc, ReminderTypes? reminderType, DateTime? remindAt);
        Task<Reminders?> CheckReminder(int id);
        Task AddReminder(Reminders reminder);
        Task<bool> DeleteReminder(int id);
    }
}
