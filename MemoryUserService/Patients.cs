using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryUserService
{
    [Index(nameof(UserID), IsUnique = true)]
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public DateTime? Birthdate { get; set; }
        public Genders? Gender { get; set; }
        public string? MedicalNotes { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int CaregiverID { get; set; }
        public DateTime LinkedAt { get; set; }
        public Users? User { get; set; }
    }
}
