using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Route: Entity
    {
        public Address StartPoint { get; set; }
        public Address Destination { get; set; }
        public Ride Ride { get; set; }
    }
}
