using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class RideRequestConfiguration : EntityConfiguration<RideRequest>
    {
        public override void Configure(EntityTypeBuilder<RideRequest> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status);
            builder.Property(x => x.CustomerId);
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();

            builder.OwnsOne(x => x.StartPoint, AddressConfiguration.Configure);
            builder.OwnsOne(x => x.DestinationPoint, AddressConfiguration.Configure);
            builder.OwnsOne(x => x.CustomerDetails, CustomerDetailsConfiguration.Configure);
        }
    }
}
