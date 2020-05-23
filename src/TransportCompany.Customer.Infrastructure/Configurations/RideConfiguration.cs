using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Customer.Infrastructure.Configurations
{
    public sealed class RideConfiguration : EntityConfiguration<Ride>
    {
        public override void Configure(EntityTypeBuilder<Ride> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FinishedDate);
            builder.Property(x => x.Status);
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();

            builder.OwnsOne(x => x.Price, MoneyConfiguration.Configure);

            builder.OwnsOne(x => x.Invoice, InvoiceConfiguration.Configure);

            builder.OwnsOne(x => x.DriverDetails, y =>
            {
                y.Property(x => x.Name)
                    .HasMaxLength(64);

                y.Property(x => x.CarModel)
                    .HasMaxLength(64);

                y.Property(x => x.Grade);
                y.Property(x => x.Photo);
            });

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Rides);

            builder.HasMany(x => x.Routes)
                .WithOne(x => x.Ride)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
