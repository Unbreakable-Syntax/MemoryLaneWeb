namespace MemoryLaneWeb
{
    public interface IPatientService
    {
        Task<bool> CheckPatient(int id);
        Task AddPatient(Patients patient);
        Task<bool> DeletePatient(int id);
    }
}
