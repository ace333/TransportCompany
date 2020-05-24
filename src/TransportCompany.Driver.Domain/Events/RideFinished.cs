using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class RideFinished : IRideFinished
    {
        public RideFinished(int driverId, int customerId, CustomerDetails customerDetails, Invoice driversInvoice)
        {
            DriverId = driverId;
            CustomerId = customerId;
            CustomerDetails = customerDetails;
            DriversInvoice = driversInvoice;
        }

        public int DriverId { get; }
        public int CustomerId { get; }
        public CustomerDetails CustomerDetails { get; }
        public Invoice DriversInvoice { get; }
    }
}
