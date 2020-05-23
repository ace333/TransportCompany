using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Customer.Infrastructure.Configurations
{
    public sealed class CustomerConfiguration : EntityConfiguration<Domain.Entities.Customer>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.PersonalInfo, PersonalInfoConfiguration.Configure);
            builder.OwnsOne(x => x.SystemInfo, SystemInfoConfiguration.Configure);

            builder.HasMany(x => x.FavoriteAddresses)
                .WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Rides)
                .WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PaymentMethods)
                .WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
