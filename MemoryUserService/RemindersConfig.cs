using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryUserService
{
    public class RemindersConfig : IEntityTypeConfiguration<Reminders>
    {
        public void Configure(EntityTypeBuilder<Reminders> builder)
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
