using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Events.Consumed
{
    public class RouteAdded
    {
        public int DriverId { get; set; }
        public Address StartPoint { get; set; }
        public Address Destination { get; set; }
    }
}
