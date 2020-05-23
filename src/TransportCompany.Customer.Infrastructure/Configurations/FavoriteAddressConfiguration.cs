using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Customer.Infrastructure.Configurations
{
    public sealed class FavoriteAddressConfiguration : EntityConfiguration<FavoriteAddress>
    {
        public override void Configure(EntityTypeBuilder<FavoriteAddress> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Type);

            builder.OwnsOne(x => x.Address, AddressConfiguration.Configure);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.FavoriteAddresses);
        }
    }
}
