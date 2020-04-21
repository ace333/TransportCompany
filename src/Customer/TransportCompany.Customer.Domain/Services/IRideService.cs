using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IRideService : IDomainService
    {
        void AddRoute(Ride ride, Route route);
        void RemoveRoute(Ride ride, Route route);
    }
}
