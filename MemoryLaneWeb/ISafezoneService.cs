namespace MemoryLaneWeb
{
    public interface ISafezoneService
    {
        Task<SafeZones?> CheckSafezone(int id);
        Task AddSafezone(SafeZones safezone);
        Task<bool> DeleteSafezone(int id);
    }
}
