using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.Services
{
    public interface IPaymentService : ISingletonService
    {
        Task PerformPayment(PaymentMethod paymentMethod, Money paymentAmount);
    }
}
