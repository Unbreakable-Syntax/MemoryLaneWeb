namespace MemoryLaneWeb
{
    public interface IUserService
    {
        Task<Users?> CheckUser(int id);
        Task<Users?> CheckUser(string? fullname, string? email, string? phone, UserRoles? role, bool? isactive);
        Task<List<Users>> CheckUsers(string? fullname, string? email, string? phone, UserRoles? role, bool? isactive);
        Task<int> AddUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}
