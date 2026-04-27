namespace MemoryLaneWeb
{
    public interface IReminderService
    {
        Task<bool> CheckReminder(int id);
        Task AddReminder(Reminders reminder);
        Task<bool> DeleteReminder(int id);
    }
}
