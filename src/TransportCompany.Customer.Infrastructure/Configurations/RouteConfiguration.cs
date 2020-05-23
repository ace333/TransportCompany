using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Customer.Infrastructure.Configurations
{
    public sealed class RouteConfiguration : EntityConfiguration<Route>
    {
        public override void Configure(EntityTypeBuilder<Route> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.StartPoint, AddressConfiguration.Configure);
            builder.OwnsOne(x => x.Destination, AddressConfiguration.Configure);

            builder.HasOne(x => x.Ride)
                .WithMany(x => x.Routes);
        }
    }
}
