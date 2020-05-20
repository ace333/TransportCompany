using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Events.Consumed
{
    public class RideCreated
    {
        public int DriverId { get; set;  }
        public int CustomerId { get; set; }
        public Address StartPoint { get; set; }
        public Address Destination { get; set; }
        public Money Price { get; set;  }
        public CustomerDetails CustomerDetails { get; set; }
    }
}
