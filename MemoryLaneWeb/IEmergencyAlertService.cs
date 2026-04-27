namespace MemoryLaneWeb
{
    public interface IEmergencyAlertService
    {
        Task<bool> CheckEmergencyAlert(long id);
        Task AddEmergencyAlert(EmergencyAlerts alert);
        Task<bool> DeleteEmergencyAlert(long id);
    }
}
