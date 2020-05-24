using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IRouteDeleted
    {
        int DriverId { get; }
        Address StartPoint { get; }
    }
}
