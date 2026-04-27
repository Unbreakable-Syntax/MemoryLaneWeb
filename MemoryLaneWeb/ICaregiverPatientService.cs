namespace MemoryLaneWeb
{
    public interface ICaregiverPatientService
    {
        Task<bool> CheckCaregiverPatient(int id);
        Task AddCaregiverPatient(CaregiverPatient patient);
        Task<bool> DeleteCaregiverPatient(int id);
    }
}
