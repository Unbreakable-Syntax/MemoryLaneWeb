namespace MemoryLaneWeb
{
    public interface ISafezoneService
    {
        Task<SafeZones?> CheckSafezone(int id);
        Task<SafeZones?> CheckSafezone(int? patientid, string? zonename, bool? isactive, int? createdby);
        Task<List<SafeZones>> CheckSafezones(int? patientid, string? zonename, bool? isactive, int? createdby);
        Task AddSafezone(SafeZones safezone);
        Task<bool> DeleteSafezone(int id);
    }
}
