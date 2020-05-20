using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IRideService : IDomainService
    {
        Ride CreateRide(Money price, int driverId, DriverDetails driverDetails, Address startPoint, Address destination);
        void AddRoute(Ride ride, Route route);
        void RemoveRoute(Ride ride, Route route);
    }
}
