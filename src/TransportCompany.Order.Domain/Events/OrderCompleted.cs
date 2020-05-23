using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Events
{
    public sealed class OrderCompleted : IDomainEvent
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
