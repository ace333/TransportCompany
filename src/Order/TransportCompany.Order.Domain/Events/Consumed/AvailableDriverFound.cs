using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Events.Consumed
{
    public sealed class AvailableDriverFound
    {
        public int DriverId { get; set; }
        public int CustomerId { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public DriverDetails DriverDetails { get; set; }
        public Address StartPoint { get; set; }
        public Address DestinationPoint { get; set; }
    }
}
