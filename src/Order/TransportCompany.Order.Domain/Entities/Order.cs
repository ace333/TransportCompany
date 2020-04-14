using TransportCompany.Order.Domain.Enums;
using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Entities
{
    public class Order: AggregateRoot
    {
        public OrderStatus Status { get; set; }
        public string Comments { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public Country ExecutionCountry { get; set; }
        public Invoice CustomersInvoice { get; set; }
        public Invoice DriversInvoice { get; set; }
    }
}
