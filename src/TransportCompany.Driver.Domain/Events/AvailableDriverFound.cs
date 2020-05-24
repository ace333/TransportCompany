using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class AvailableDriverFound : IAvailableDriverFound
    {
        public AvailableDriverFound(int driverId,
            int customerId,
            CustomerDetails customerDetails,
            DriverDetails driverDetails,
            Address startPoint,
            Address destinationPoint)
        {
            DriverId = driverId;
            CustomerId = customerId;
            CustomerDetails = customerDetails;
            DriverDetails = driverDetails;
            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
        }

        public int DriverId { get; }
        public int CustomerId { get; }
        public CustomerDetails CustomerDetails { get; }
        public DriverDetails DriverDetails { get; }
        public Address StartPoint { get; }
        public Address DestinationPoint { get; }
    }
}
