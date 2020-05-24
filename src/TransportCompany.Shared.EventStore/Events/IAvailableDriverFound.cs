using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IAvailableDriverFound
    {
        int DriverId { get; }
        int CustomerId { get; }
        CustomerDetails CustomerDetails { get; }
        DriverDetails DriverDetails { get; }
        Address StartPoint { get; }
        Address DestinationPoint { get; }
    }
}
