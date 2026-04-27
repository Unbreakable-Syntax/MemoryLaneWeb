namespace MemoryLaneWeb
{
    public interface IFamilyPatientService
    {
        Task<FamilyPatient?> CheckFamilyPatient(int id);
        Task AddFamilyPatient(FamilyPatient fpatient);
        Task<bool> DeleteFamilyPatient(int id);
    }
}
