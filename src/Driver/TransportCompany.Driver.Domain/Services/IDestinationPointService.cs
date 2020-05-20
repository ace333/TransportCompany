using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IDestinationPointService : IDomainService
    {
        DestinationPoint CreateStopPoint(Address address);
    }
}
