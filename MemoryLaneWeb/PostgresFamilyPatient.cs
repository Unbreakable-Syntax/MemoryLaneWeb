using Microsoft.EntityFrameworkCore;

namespace MemoryLaneWeb
{
    public class PostgresFamilyPatient : IFamilyPatientService
    {
        private readonly AppDbContext _db;

        public PostgresFamilyPatient(AppDbContext db)
        {
            _db = db;
        }

        public async Task<FamilyPatient?> CheckFamilyPatient(int id)
        {
            var fpatient = await _db.FamilyPatient.FindAsync(id);
            if (fpatient == null) return null;
            return fpatient;
        }

        public async Task<FamilyPatient?> CheckFamilyPatient(int? familyid, int? patientid, string rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat)
        {
            var query = _db.FamilyPatient.AsQueryable();
            if (familyid.HasValue) query = query.Where(u => u.FamilyID == familyid.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (canviewloc.HasValue) query = query.Where(u => u.CanViewAlerts == canviewloc.Value);
            if (canviewalert.HasValue) query = query.Where(u => u.CanViewLocation == canviewalert.Value);
            if (assignedat.HasValue) query = query.Where(u => u.AssignedAt == assignedat.Value);
            var familypatient = await query.FirstOrDefaultAsync();
            return familypatient;
        }

        public async Task<List<FamilyPatient>> CheckFamilyPatients(int? familyid, int? patientid, string rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat)
        {
            var query = _db.FamilyPatient.AsQueryable();
            if (familyid.HasValue) query = query.Where(u => u.FamilyID == familyid.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            if (canviewloc.HasValue) query = query.Where(u => u.CanViewAlerts == canviewloc.Value);
            if (canviewalert.HasValue) query = query.Where(u => u.CanViewLocation == canviewalert.Value);
            if (assignedat.HasValue) query = query.Where(u => u.AssignedAt == assignedat.Value);
            var familypatients = await query.ToListAsync();
            return familypatients;
        }

        public async Task AddFamilyPatient(FamilyPatient fpatient)
        {
            _db.FamilyPatient.Add(fpatient);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteFamilyPatient(int id)
        {
            var fpatient = await _db.FamilyPatient.FindAsync(id);
            if (fpatient == null) return false;
            _db.FamilyPatient.Remove(fpatient);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
