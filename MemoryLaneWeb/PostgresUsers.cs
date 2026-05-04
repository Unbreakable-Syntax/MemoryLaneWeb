using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresUsers : IUserService
    {
        private readonly AppDbContext _db;

        public PostgresUsers(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Users?> CheckUserEmail(string? email)
        {
            var query = _db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(email)) query = query.Where(r => r.Email == email);
            var users = await query.FirstOrDefaultAsync();
            return users;
        }

        public async Task<Users?> CheckUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return null;
            return user;
        }

        public async Task<int> AddUser(Users user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user.UserID;
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
