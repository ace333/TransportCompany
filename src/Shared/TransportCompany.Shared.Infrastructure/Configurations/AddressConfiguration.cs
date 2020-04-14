using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Infrastructure.Configurations
{
    public static class AddressConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, Address> builder) 
            where TEntity: class
        {
            builder.Property(x => x.Street)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.HouseNumber)
                .HasMaxLength(64);

            builder.Property(x => x.ZipCode)
                .HasMaxLength(64);

            builder.Property(x => x.City)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.State)
                .HasMaxLength(64);

            builder.Property(x => x.Country)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
