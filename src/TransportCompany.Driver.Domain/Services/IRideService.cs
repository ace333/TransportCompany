using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IRideService : IDomainService
    {
        Ride CreateNewRide(Address startPoint, Address destinationPoint, Money income,
            int customerId, CustomerDetails customerDetails);
        void AddStop(Ride ride, Address startPoint, Address destinationPoint);
        void RemoveStop(Ride ride, Address startPoint);
    }
}
