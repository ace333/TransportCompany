using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.Services.PaymentStrategy
{
    public interface IPaymentStrategyResolver : ISingletonService
    {
        PaymentStrategy Resolve(PaymentMethod paymentMethod);
    }
}
