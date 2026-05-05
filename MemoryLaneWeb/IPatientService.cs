namespace MemoryLaneWeb
{
    public interface IPatientService
    {
        Task<Patients?> CheckPatient(int id);

        Task<Patients?> CheckPatient(int? userid, DateTime? birthdate, Genders? gender, string? medcon, int? age, string? meds, string? allergies);

        Task<List<Patients>> CheckPatients(int? userid, DateTime? birthdate, Genders? gender, string? medcon, int? age, string? meds, string? allergies);

        Task AddPatient(Patients patient);

        Task<bool> UpdatePatient(int id, int? age, string? medcons, string? meds, string? allergies);

        Task<bool> DeletePatient(int id);
    }
}
