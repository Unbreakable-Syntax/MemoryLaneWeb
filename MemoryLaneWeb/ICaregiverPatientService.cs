namespace MemoryLaneWeb
{
    public interface ICaregiverPatientService
    {
        Task<CaregiverPatient?> CheckCaregiverPatient(int id);
        Task<CaregiverPatient?> CheckCaregiverPatient(int? caregiverid, int? patientid, string emername, string emerphone);
        Task<List<CaregiverPatient>> CheckCaregiverPatients(int? caregiverid, int? patientid, string emername, string emerphone);
        Task AddCaregiverPatient(CaregiverPatient patient);
        Task<bool> DeleteCaregiverPatient(int id);
    }
}
