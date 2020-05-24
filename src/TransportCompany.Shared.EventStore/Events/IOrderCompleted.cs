using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IOrderCompleted
    {
        int CustomerId { get; }
        Invoice CustomersInvoice { get; }
    }
}
