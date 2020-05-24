using System.Threading.Tasks;
using TransportCompany.Customer.Application.Services.PaymentStrategy;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentStrategyResolver _paymentStrategyResolver;

        public PaymentService(IPaymentStrategyResolver paymentStrategyResolver)
        {
            _paymentStrategyResolver = paymentStrategyResolver;
        }

        public async Task PerformPayment(PaymentMethod paymentMethod, Money paymentAmount)
        {
            var strategy = _paymentStrategyResolver.Resolve(paymentMethod);
            await strategy.Execute(paymentAmount);
        }
    }
}
