using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Services.PaymentStrategy
{
    public abstract class PaymentStrategy : IStrategy
    {
        protected readonly PaymentMethod PaymentMethod;

        protected PaymentStrategy(PaymentMethod paymentMethod)
        {
            PaymentMethod = paymentMethod;
        }

        public abstract Task Execute(Money paymentAmount);
    }
}
