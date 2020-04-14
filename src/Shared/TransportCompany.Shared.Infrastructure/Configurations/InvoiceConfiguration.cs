using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Infrastructure.Configurations
{
    public static class InvoiceConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, Invoice> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Name)
                .HasMaxLength(255);

            builder.Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Content);
        }
    }
}
