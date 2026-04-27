namespace MemoryLaneWeb
{
    public interface IPatientLocationService
    {
        Task<PatientLocations?> CheckPatientLocation(long id);
        Task AddPatientLocation(PatientLocations location);
        Task<bool> DeletePatientLocation(long id);
    }
}
