namespace MemoryLaneWeb
{
    public interface IPatientService
    {
        Task<Patients?> CheckPatient(int id);
        Task AddPatient(Patients patient);
        Task<bool> DeletePatient(int id);
    }
}
