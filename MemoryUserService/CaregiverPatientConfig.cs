using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryUserService
{
    public class CaregiverPatientConfig : IEntityTypeConfiguration<CaregiverPatient>
    {
        public void Configure(EntityTypeBuilder<CaregiverPatient> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.CaregiverID)
                .HasPrincipalKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientID)
                .HasPrincipalKey(u => u.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
