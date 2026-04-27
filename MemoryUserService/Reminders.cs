using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryUserService
{
    [Index(nameof(PatientID))]
    [Index(nameof(RemindAt))]
    [Index(nameof(CreatedBy))]
    public class Reminders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReminderID { get; set; }
        public int PatientID { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ReminderTypes ReminderType { get; set; } = ReminderTypes.Medication;
        public DateTime RemindAt { get; set; } 
        public ReminderOccurence Recurrences { get; set; } = ReminderOccurence.None;
        public bool IsAcknowledged { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Users? User { get; set; }
        public Patients? Patient { get; set; }  
    }
}
