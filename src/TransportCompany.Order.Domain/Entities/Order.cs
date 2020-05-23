using TransportCompany.Order.Domain.Enums;
using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Entities
{
    public class Order: AggregateRoot
    {
        public Order(int customerId, int driverId)
        {
            CustomerId = customerId;
            DriverId = driverId;
            Status = OrderStatus.Started;
        }

        public OrderStatus Status { get; protected set; }
        public int CustomerId { get; protected set; }
        public int DriverId { get; protected set; }
        public string Comments { get; protected set; }
        public Country ExecutionCountry { get; protected set; }
        public PaymentAmount PaymentAmount { get; protected set; }
        public Invoice CustomersInvoice { get; protected set; }
        public Invoice DriversInvoice { get; protected set; }

        public void Cancel(string comments = null)
        {
            Status = OrderStatus.Cancelled;
            Comments = comments != null ? comments : "Order cancelled by Driver";
        }

        public void Complete() => Status = OrderStatus.Completed;
        public void SetExecutionCountry(Country country) => ExecutionCountry = country;
        public void SetPaymentAmount(PaymentAmount paymentAmount) => PaymentAmount = paymentAmount;
        public void SetDriverInvoice(Invoice invoice) => DriversInvoice = invoice;
        public void SetCustomerInvoice(Invoice invoice) => CustomersInvoice = invoice;
    }
}
