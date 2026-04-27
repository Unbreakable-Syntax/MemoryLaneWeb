using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryLaneWeb
{
    [Index(nameof(SenderID), nameof(RecipientID))]
    [Index(nameof(RecipientID), nameof(IsRead))]
    [Index(nameof(PatientID))]
    public class ChatMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SenderID { get; set; }
        public string? SenderName { get; set; }
        public string? SenderRole { get; set; }
        public int RecipientID { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public int PatientID { get; set; }
    }
}
