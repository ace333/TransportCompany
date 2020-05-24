using MassTransit;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Persistence
{
    public class OrderDbContext : BaseDbContext<OrderDbContext>
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options, IBusControl busControl)
            : base(options, busControl)
        {
        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Order>()
                .ToTable("Order");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
        }
    }
}
