using Microsoft.EntityFrameworkCore;

namespace MemoryUserService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<Users> Users { get; set; }
        public DbSet<SafeZones> SafeZones { get; set; }
        public DbSet<Reminders> Reminders { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<PatientLocations> PatientLocations { get; set; }
        public DbSet<FamilyPatient> FamilyPatient { get; set; }
        public DbSet<CaregiverPatient> CaregiverPatient { get; set; }
        public DbSet<EmergencyAlerts> EmergencyAlerts { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply all configurations created
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Patients patient &&
                    entry.State == EntityState.Modified)
                {
                    patient.LinkedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
