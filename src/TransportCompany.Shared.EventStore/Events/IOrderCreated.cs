using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IOrderCreated
    {
        int CustomerId { get; }
        int DriverId { get; }
        Money Price { get; }
        CustomerDetails CustomerDetails { get; }
        DriverDetails DriverDetails { get; }
        Address StartPoint { get; }
        Address Destination { get; }
    }
}
