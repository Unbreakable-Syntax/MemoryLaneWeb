namespace MemoryLaneWeb
{
    public interface IPatientLocationService
    {
        Task<bool> CheckPatientLocation(long id);
        Task AddPatientLocation(PatientLocations location);
        Task<bool> DeletePatientLocation(long id);
    }
}
