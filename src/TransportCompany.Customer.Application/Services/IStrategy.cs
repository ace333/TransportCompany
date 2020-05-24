using System.Threading.Tasks;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Services
{
    public interface IStrategy
    {
        Task Execute(Money paymentAmount);
    }
}
