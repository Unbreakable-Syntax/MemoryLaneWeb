namespace MemoryLaneWeb
{
    public interface IFamilyPatientService
    {
        Task<FamilyPatient?> CheckFamilyPatient(int id);
        Task<FamilyPatient?> CheckFamilyPatient(int? familyid, int? patientid, string? rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat);
        Task<List<FamilyPatient>> CheckFamilyPatients(int? familyid, int? patientid, string? rs, bool? canviewloc, bool? canviewalert, DateTime? assignedat); 
        Task AddFamilyPatient(FamilyPatient fpatient);
        Task<bool> DeleteFamilyPatient(int id);
    }
}
