using MassTransit;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Persistence
{
    public class CustomerDbContext: DbContext// BaseDbContext<CustomerDbContext>
    {
        //public CustomerDbContext(DbContextOptions<CustomerDbContext> options, IBusControl busControl) 
        //    : base(options, busControl)
        //{
        //}

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<PaymentMethod>()
                .ToTable("PaymentMethod")
                .HasDiscriminator(x => x.Type)
                .HasValue<DebitOrCreditCard>(PaymentMethodType.DebitOrCreditCard)
                .HasValue<PayPal>(PaymentMethodType.PayPal);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);
        }
    }
}
