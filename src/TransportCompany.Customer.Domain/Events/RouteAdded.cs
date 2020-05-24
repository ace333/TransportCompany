using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RouteAdded : IRouteAdded
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
