using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IDestinationPointService : IDomainService
    {
        DestinationPoint CreateDestinationPoint(Address address, DestinationPoint previousPoint = null);
        void UpdateDestinationPoint(Ride ride, int stopId);
    }
}
