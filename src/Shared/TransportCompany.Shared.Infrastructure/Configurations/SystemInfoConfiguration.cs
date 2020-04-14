using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Infrastructure.Configurations
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
