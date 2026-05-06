namespace MemoryLaneWeb
{
    public interface IPatientLocationService
    {
        Task<PatientLocations?> CheckPatientLocation(long id);
        Task<PatientLocations?> CheckPatientLocation(int? patientid, GPSSources? source, DateTime? recordedat, string? orderby, bool? isdesc);
        Task<List<PatientLocations>> CheckPatientLocations(int? patientid, GPSSources? source, DateTime? recordedat, string? orderby, bool? isdesc);
        Task AddPatientLocation(PatientLocations location);
        Task<bool> DeletePatientLocation(long id);
    }
}
