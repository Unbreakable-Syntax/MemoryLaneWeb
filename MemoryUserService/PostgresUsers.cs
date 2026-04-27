namespace MemoryUserService
{
    public class PostgresUsers : IUserService
    {
        private readonly AppDbContext _db;

        public PostgresUsers(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;
            return true;
        }

        public async Task AddUser(Users user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
