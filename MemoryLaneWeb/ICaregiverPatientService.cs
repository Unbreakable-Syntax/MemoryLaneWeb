namespace MemoryLaneWeb
{
    public interface ICaregiverPatientService
    {
        Task<CaregiverPatient?> CheckCaregiverPatient(int id);
        Task AddCaregiverPatient(CaregiverPatient patient);
        Task<bool> DeleteCaregiverPatient(int id);
    }
}
