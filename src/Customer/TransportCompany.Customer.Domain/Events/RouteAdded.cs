using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RouteAdded : IDomainEvent
    {
        public RouteAdded(int driverId, Address startPoint, Address destination)
        {
            DriverId = driverId;
            StartPoint = startPoint;
            Destination = destination;
        }

        public int DriverId { get; }
        public Address StartPoint { get; }
        public Address Destination { get; }
    }
}
