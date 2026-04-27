using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryUserService
{
    [Index(nameof(PatientID))]
    [Index(nameof(TriggeredAt))]
    [Index(nameof(IsResolved))]
    [Index(nameof(ResolvedBy))]
    public class EmergencyAlerts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AlertID { get; set; }
        public int PatientID { get; set; }
        public AlertTypes AlertType { get; set; } = AlertTypes.SOS;
        public Severities Severity { get; set; } = Severities.High;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Message { get; set; }
        public bool IsResolved { get; set; } = false;
        public int? ResolvedBy { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime TriggeredAt { get; set; } = DateTime.UtcNow;
        public Users? User { get; set; }
        public Patients? Patient { get; set; }
    }
}
