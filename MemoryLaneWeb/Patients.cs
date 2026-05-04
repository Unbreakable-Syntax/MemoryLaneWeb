using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryLaneWeb
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
        public string? MedicalConditions { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? Age { get; set; }
        public string? Medications { get; set; }
        public string? Allergies { get; set; }
        public Users? User { get; set; }
    }
}
