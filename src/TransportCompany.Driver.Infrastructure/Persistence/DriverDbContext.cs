using MassTransit;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Persistence
{
    public class DriverDbContext : BaseDbContext<DriverDbContext>
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options, IBusControl busControl)
            : base(options, busControl)
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
