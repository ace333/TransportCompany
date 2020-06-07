using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Route: Entity
    {
        public Route(Address destinationPoint, Route previousRoute = null)
        {
            DestinationPoint = destinationPoint;
            PreviousRoute = previousRoute;
        }

        protected Route() { }

        public Address DestinationPoint { get; set; }
        public Route PreviousRoute { get; set; }

        public Ride Ride { get; set; }
    }
}
