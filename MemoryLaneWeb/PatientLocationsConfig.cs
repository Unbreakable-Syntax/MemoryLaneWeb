using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryLaneWeb
{
    public class PatientLocationsConfig : IEntityTypeConfiguration<PatientLocations>
    {
        public void Configure(EntityTypeBuilder<PatientLocations> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientID)
                .HasPrincipalKey(u => u.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
