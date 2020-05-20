using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class PersonalInfoConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, PersonalInfo> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(64);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(64);

            builder.Property(x => x.Nationality);
            builder.Property(x => x.Photo);
        }
    }
}
