using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IRideRequested
    {
        int CustomerId { get; }
        CustomerDetails CustomerDetails { get; }
        Address StartPoint { get; }
        Address DestinationPoint { get; }
    }
}
