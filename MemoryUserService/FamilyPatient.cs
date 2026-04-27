using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryUserService
{
    [Index(nameof(FamilyID), nameof(PatientID), IsUnique = true)]
    [Index(nameof(FamilyID))]
    [Index(nameof(PatientID))]
    public class FamilyPatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FamilyID { get; set; }
        public int PatientID { get; set; }
        public string? Relationship { get; set; }
        public bool CanViewLocation { get; set; } = true;
        public bool CanViewAlerts { get; set; } = true;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public Users? User { get; set; }
        public Patients? Patient { get; set;}
    }
}
