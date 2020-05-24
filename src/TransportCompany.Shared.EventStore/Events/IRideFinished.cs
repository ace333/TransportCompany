using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IRideFinished
    {
        int DriverId { get; }
        int CustomerId { get; }
        Invoice DriversInvoice { get; }
        CustomerDetails CustomerDetails { get; }
    }
}
