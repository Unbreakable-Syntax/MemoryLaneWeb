namespace MemoryLaneWeb
{
    public interface IUserService
    {
        Task<Users?> CheckUser(int id);
        Task<Users?> CheckUserEmail(string? email);
        Task<int> AddUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}
