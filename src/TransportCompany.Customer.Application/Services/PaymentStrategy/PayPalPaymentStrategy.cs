using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Services.PaymentStrategy
{
    public class PayPalPaymentStrategy : PaymentStrategy
    {
        public PayPalPaymentStrategy(PaymentMethod paymentMethod) : base(paymentMethod)
        {
        }

        public override Task Execute(Money paymentAmount)
        {
            // Method should be able to communicate with payments provider and perform operation.
            // Customers pay pal account should be used to perform transaction.
            // For a demo purposes method would just return Task.CompletedTask.
            return Task.CompletedTask;
        }
    }
}
