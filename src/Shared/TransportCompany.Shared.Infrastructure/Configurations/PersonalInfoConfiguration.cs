using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Infrastructure.Configurations
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
