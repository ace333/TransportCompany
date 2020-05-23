using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IDestinationPointService : IDomainService
    {
        DestinationPoint CreateStopPoint(Address address);
    }
}
