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
        public string? Notes { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public Users? User { get; set; }
        public Patients? Patient { get; set; }
    }
}
