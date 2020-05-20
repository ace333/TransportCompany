using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class SystemInfoConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, SystemInfo> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Grade);
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();
        }
    }
}
