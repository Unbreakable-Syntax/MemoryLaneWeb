namespace MemoryUserService
{
    public interface IFamilyPatientService
    {
        Task<bool> CheckFamilyPatient(int id);
        Task AddFamilyPatient(FamilyPatient fpatient);
        Task<bool> DeleteFamilyPatient(int id);
    }
}
