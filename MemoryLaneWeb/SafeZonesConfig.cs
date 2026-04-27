using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryLaneWeb
{
    public class SafeZonesConfig : IEntityTypeConfiguration<SafeZones>
    {
        public void Configure(EntityTypeBuilder<SafeZones> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .HasPrincipalKey(u => u.UserID)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientID)
                .HasPrincipalKey(u => u.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
