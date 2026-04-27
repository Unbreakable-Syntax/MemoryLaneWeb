namespace MemoryLaneWeb
{
    public interface IUserService
    {
        Task<Users?> CheckUser(int id);
        Task AddUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}
