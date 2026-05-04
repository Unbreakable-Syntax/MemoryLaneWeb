namespace MemoryLaneWeb
{
    public interface IPatientService
    {
        Task<Patients?> CheckPatient(int id);
        Task AddPatient(Patients patient);

        Task<bool> UpdatePatient(int id, int? age, string? medcons, string? meds, string? allergies);

        Task<bool> DeletePatient(int id);
    }
}
