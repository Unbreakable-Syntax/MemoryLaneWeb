namespace MemoryLaneWeb
{
    public interface ISafezoneService
    {
        Task<bool> CheckSafezone(int id);
        Task AddSafezone(SafeZones safezone);
        Task<bool> DeleteSafezone(int id);
    }
}
