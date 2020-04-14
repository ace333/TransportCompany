using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class DriverConfiguration : EntityConfiguration<Domain.Entities.Driver>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Driver> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Priority);
            builder.OwnsOne(x => x.PersonalInfo, PersonalInfoConfiguration.Configure);
            builder.OwnsOne(x => x.SystemInfo, SystemInfoConfiguration.Configure);

            builder.OwnsOne(x => x.Car, y =>
            {
                y.Property(x => x.Model)
                    .HasMaxLength(64)
                    .IsRequired();

                y.Property(x => x.RegistrationPlateNumber)
                    .HasMaxLength(64)
                    .IsRequired();
            });

            builder.OwnsOne(x => x.DriversLicense, y =>
            {
                y.Property(x => x.Number)
                    .HasMaxLength(64)
                    .IsRequired();

                y.Property(x => x.DateOfIssue);
                y.Property(x => x.ExpiryDate);
            });

            builder.OwnsOne(x => x.CompanyDetails, y =>
            {
                y.Property(x => x.CompanyName)
                    .HasMaxLength(255)
                    .IsRequired();

                y.Property(x => x.OwnerName)
                    .HasMaxLength(255)
                    .IsRequired();

                y.Property(x => x.NationalEconomyRegisterNumber);
                y.Property(x => x.TaxIdentificationNumber);

                y.OwnsOne(x => x.Address, AddressConfiguration.Configure);

                y.OwnsOne(x => x.BankDetails, z =>
                {
                    z.Property(x => x.BankName)
                        .HasMaxLength(64)
                        .IsRequired();

                    z.Property(x => x.AccountNumber)
                        .HasMaxLength(64)
                        .IsRequired();
                });
            });

            builder.HasMany(x => x.Rides)
                .WithOne(x => x.Driver)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
