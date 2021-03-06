﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class RideConfiguration : EntityConfiguration<Ride>
    {
        public override void Configure(EntityTypeBuilder<Ride> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status);
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();

            builder.OwnsOne(x => x.Invoice, InvoiceConfiguration.Configure);
            builder.OwnsOne(x => x.Income, MoneyConfiguration.Configure);

            builder.Property(x => x.CustomerId);
            builder.OwnsOne(x => x.CustomerDetails, CustomerDetailsConfiguration.Configure);

            builder.HasOne(x => x.Driver)
                .WithMany(x => x.Rides);

            builder.HasMany(x => x.Stops)
                .WithOne(x => x.Ride)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
