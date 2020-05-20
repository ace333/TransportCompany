using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Order.Infrastructure.Configurations
{
    public class OrderConfiguration : EntityConfiguration<Domain.Entities.Order>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Order> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status);
            builder.Property(x => x.Comments)
                .HasMaxLength(255);

            builder.Property(x => x.CustomerId);
            builder.Property(x => x.DriverId);
            builder.Property(x => x.ExecutionCountry);

            builder.OwnsOne(x => x.CustomersInvoice, InvoiceConfiguration.Configure);
            builder.OwnsOne(x => x.DriversInvoice, InvoiceConfiguration.Configure);

            builder.OwnsOne(x => x.PaymentAmount, y =>
            {
                y.Property(x => x.Currency)
                    .HasMaxLength(64)
                    .IsRequired();

                y.Property(x => x.NetValue);
                y.Property(x => x.GrossValue);
                y.Property(x => x.Tax);
            });
        }
    }
}
