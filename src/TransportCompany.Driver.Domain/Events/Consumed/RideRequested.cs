using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Events.Consumed
{
    public class RideRequested
    {
        public int CustomerId { get; set;  }
        public CustomerDetails CustomerDetails { get; set; }
        public Address StartPoint { get; set; }
        public Address DestinationPoint { get; set; }
    }
}
