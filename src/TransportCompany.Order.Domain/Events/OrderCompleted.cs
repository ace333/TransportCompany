using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Domain.Events
{
    public sealed class OrderCompleted : IOrderCompleted
    {
        public OrderCompleted(int customerId, Invoice customersInvoice)
        {
            CustomerId = customerId;
            CustomersInvoice = customersInvoice;
        }

        public int CustomerId { get; }
        public Invoice CustomersInvoice { get; } 
    }
}
