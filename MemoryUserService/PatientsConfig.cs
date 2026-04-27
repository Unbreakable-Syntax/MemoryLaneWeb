using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryUserService
{
    public class PatientsConfig : IEntityTypeConfiguration<Patients>
    {
        public void Configure(EntityTypeBuilder<Patients> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserID)
                .HasPrincipalKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
