namespace MemoryLaneWeb
{
    public interface IReminderService
    {
        Task<Reminders?> CheckReminder(int id);
        Task AddReminder(Reminders reminder);
        Task<bool> DeleteReminder(int id);
    }
}
