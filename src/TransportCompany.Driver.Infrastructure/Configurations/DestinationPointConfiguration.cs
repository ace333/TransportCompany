using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class DestinationPointConfiguration : EntityConfiguration<DestinationPoint>
    {
        public override void Configure(EntityTypeBuilder<DestinationPoint> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status);
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();

            builder.OwnsOne(x => x.Address, AddressConfiguration.Configure);

            builder.HasOne(x => x.Ride)
                .WithMany(x => x.Stops);

            builder.HasOne(x => x.PreviousPoint);
        }
    }
}
