using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryLaneWeb
{
    [Index(nameof(PatientID))]
    [Index(nameof(RecordedAt))]
    public class PatientLocations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LocationID { get; set; }
        public int PatientID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
        public double? AccuracyM { get; set; }
        public GPSSources Source { get; set; } = GPSSources.GPS;
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
        public Patients? Patient { get; set; }
    }
}
