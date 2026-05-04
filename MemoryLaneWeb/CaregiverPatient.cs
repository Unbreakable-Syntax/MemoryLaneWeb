using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryLaneWeb
{
    [Index(nameof(CaregiverID), nameof(PatientID), IsUnique = true)]
    [Index(nameof(PatientID))]
    [Index(nameof(CaregiverID))]
    public class CaregiverPatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CaregiverID { get; set; }
        public int PatientID { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public double? SafeZoneRadius { get; set; } = 100.0;
        public double? SafeZoneLatitude { get; set; } = 0.0;
        public double? SafeZoneLongitude { get; set; } = 0.0;
        public DateTime? LinkedAt { get; set; } = DateTime.UtcNow;
        public Users? User { get; set; }
        public Patients? Patient { get; set; }
    }
}
