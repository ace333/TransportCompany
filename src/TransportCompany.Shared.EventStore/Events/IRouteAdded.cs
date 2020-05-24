using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IRouteAdded
    {
        int DriverId { get; }
        Address StartPoint { get; }
        Address Destination { get; }
    }
}
