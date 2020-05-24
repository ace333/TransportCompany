using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Infrastructure.Configurations;

namespace TransportCompany.Customer.Infrastructure.Configurations
{
    public class PaymentMethodConfiguration : EntityConfiguration<PaymentMethod>
    {
        public override void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Type);
            builder.Property(x => x.IsPreffered);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.PaymentMethods);
        }
    }

    public class DebitOrCreditCardConfiguration : EntityConfiguration<DebitOrCreditCard>
    {
        public override void Configure(EntityTypeBuilder<DebitOrCreditCard> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CardNumber);
            builder.Property(x => x.CvvCode);
            builder.Property(x => x.Country);
            builder.Property(x => x.ExpiryDate);
        }
    }

    public class PayPalConfiguration : EntityConfiguration<PayPal>
    {
        public override void Configure(EntityTypeBuilder<PayPal> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.IsAlwaysLoggedIn);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(64);
        }
    }
}
