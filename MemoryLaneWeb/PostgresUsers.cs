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

        public async Task<string?> CallUser(int patientid)
        {
            var phone = await _db.Patients
            .Where(p => p.PatientID == patientid)
            .Join(_db.Users,
            p => p.UserID,
            u => u.UserID,
            (p, u) => u.Phone)
            .FirstOrDefaultAsync();
            return phone;
        }

        public async Task<Users?> CheckUser(string? fullname, string? email, string? phone, UserRoles? role, bool? isactive)
        {
            var query = _db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(fullname)) query = query.Where(u => fullname.Equals(u.FullName));
            if (!string.IsNullOrEmpty(email)) query = query.Where(u => email.Equals(u.Email));
            if (!string.IsNullOrEmpty(phone)) query = query.Where(u => phone.Equals(u.Phone));
            if (role.HasValue) query = query.Where(u => u.Role == role.Value);
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            var user = await query.FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<Users>> CheckUsers(string? fullname, string? email, string? phone, UserRoles? role, bool? isactive)
        {
            var query = _db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(fullname)) query = query.Where(u => fullname.Equals(u.FullName));
            if (!string.IsNullOrEmpty(email)) query = query.Where(u => email.Equals(u.Email));
            if (!string.IsNullOrEmpty(phone)) query = query.Where(u => phone.Equals(u.Phone));
            if (role.HasValue) query = query.Where(u => u.Role == role.Value);
            if (isactive.HasValue) query = query.Where(u => u.IsActive == isactive.Value);
            var users = await query.ToListAsync();
            return users;
        }

        public async Task<Users?> CheckUserEmail(string? email)
        {
            var query = _db.Users.AsQueryable();
            
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
