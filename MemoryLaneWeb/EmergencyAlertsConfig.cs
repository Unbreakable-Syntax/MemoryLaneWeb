using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryLaneWeb
{
    public class EmergencyAlertsConfig : IEntityTypeConfiguration<EmergencyAlerts>
    {
        public void Configure(EntityTypeBuilder<EmergencyAlerts> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientID)
                .HasPrincipalKey(u => u.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.ResolvedBy)
                .HasPrincipalKey(u => u.UserID)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
