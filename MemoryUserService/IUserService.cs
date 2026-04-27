namespace MemoryUserService
{
    public interface IUserService
    {
        Task<bool> CheckUser(int id);
        Task AddUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}
