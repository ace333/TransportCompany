using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Events.Consumed
{
    public sealed class RideFinished
    {
        public int DriverId { get; set;  }
        public int CustomerId { get; set; }
        public Invoice DriversInvoice { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
}
