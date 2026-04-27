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
