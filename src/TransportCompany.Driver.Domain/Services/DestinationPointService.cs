using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public class DestinationPointService : IDestinationPointService
    {
        public DestinationPoint CreateStopPoint(Address address)
            => new DestinationPoint(PointStatus.OnTheWay, PointType.Stop, address);
    }
}
