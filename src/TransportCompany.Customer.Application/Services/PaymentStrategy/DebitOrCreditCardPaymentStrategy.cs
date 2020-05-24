using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Services.PaymentStrategy
{
    public class DebitOrCreditCardPaymentStrategy : PaymentStrategy
    {
        public DebitOrCreditCardPaymentStrategy(PaymentMethod paymentMethod) : base(paymentMethod)
        {
        }

        public override Task Execute(Money paymentAmount)
        {
            // Method should be able to communicate with payments provider and perform operation.
            // Customer debit or credit card should be used to perform transaction.
            // For a demo purposes method would just return Task.CompletedTask.
            return Task.CompletedTask;
        }
    }
}
