using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class CustomerDetailsConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, CustomerDetails> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Name)
                .HasMaxLength(64);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(64);

            builder.Property(x => x.Grade)
                .HasColumnType("decimal(18, 2)");            
        }
    }
}
