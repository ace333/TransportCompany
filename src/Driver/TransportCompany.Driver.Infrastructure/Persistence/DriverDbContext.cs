using Microsoft.EntityFrameworkCore;

namespace TransportCompany.Driver.Infrastructure.Persistence
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Driver>()
                .ToTable("Driver");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DriverDbContext).Assembly);
        }
    }
}
