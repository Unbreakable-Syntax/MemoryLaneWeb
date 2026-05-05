namespace MemoryLaneWeb
{
    public interface IEmergencyAlertService
    {
        Task<EmergencyAlerts?> CheckEmergencyAlert(long id);
        Task<EmergencyAlerts?> CheckEmergencyAlert(int? patientid, AlertTypes? alerttype, Severities? severity, bool? isresolved, int? resolvedby, DateTime? resolvedat, DateTime? triggered);
        Task<List<EmergencyAlerts>> CheckEmergencyAlerts(int? patientid, AlertTypes? alerttype, Severities? severity, bool? isresolved, int? resolvedby, DateTime? resolvedat, DateTime? triggered);
        Task AddEmergencyAlert(EmergencyAlerts alert);
        Task<bool> DeleteEmergencyAlert(long id);
    }
}
