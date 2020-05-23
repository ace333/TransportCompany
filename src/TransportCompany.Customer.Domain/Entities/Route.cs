using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Route: Entity
    {
        public Route(Address startPoint, Address destination)
        {
            StartPoint = startPoint;
            Destination = destination;
        }

        protected Route() { }

        public Address StartPoint { get; set; }
        public Address Destination { get; set; }
        public Ride Ride { get; set; }

        public IEnumerable<Address> GetAddresses => new Address[] {StartPoint, Destination};
    }
}
