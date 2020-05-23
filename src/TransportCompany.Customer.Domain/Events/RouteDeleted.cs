using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RouteDeleted : IDomainEvent
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
