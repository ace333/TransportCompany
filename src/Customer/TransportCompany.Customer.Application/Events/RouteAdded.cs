using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Events
{
    public sealed class RouteAdded : IDomainEvent
    {
        public RouteAdded(Address startPoint, Address destination)
        {
            StartPoint = startPoint;
            Destination = destination;
        }

        public Address StartPoint { get; }
        public Address Destination { get; }
    }
}
