using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RouteDeleted : IRouteDeleted
    {
        public RouteDeleted(int driverId, Address startPoint)
        {
            DriverId = driverId;
            StartPoint = startPoint;
        }

        public int DriverId { get; }
        public Address StartPoint { get; }        
    }
}
