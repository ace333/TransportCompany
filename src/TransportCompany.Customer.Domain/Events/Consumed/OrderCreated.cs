using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Events.Consumed
{
    public class OrderCreated
    {
        public int CustomerId { get; set;  }
        public int DriverId { get; set; }
        public Money Price { get; set; }
        public DriverDetails DriverDetails { get; set; }
        public Address StartPoint { get; set; }
        public Address Destination { get; set; }
    }
}
