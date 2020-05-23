using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Events.Consumed
{
    public class RouteDeleted
    {
        public int DriverId { get; set; }
        public Address StartPoint { get; }
    }
}
