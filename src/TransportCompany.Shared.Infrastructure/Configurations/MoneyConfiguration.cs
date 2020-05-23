using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Infrastructure.Configurations
{
    public class MoneyConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, Money> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Currency)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();
        }
    }
}
