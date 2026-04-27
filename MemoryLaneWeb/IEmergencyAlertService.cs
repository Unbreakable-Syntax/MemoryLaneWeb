namespace MemoryLaneWeb
{
    public interface IEmergencyAlertService
    {
        Task<EmergencyAlerts?> CheckEmergencyAlert(long id);
        Task AddEmergencyAlert(EmergencyAlerts alert);
        Task<bool> DeleteEmergencyAlert(long id);
    }
}
