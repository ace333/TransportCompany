using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RideRequested : IRideRequested
    {
        public RideRequested(int customerId, CustomerDetails customerDetails, Address startPoint, Address destinationPoint)
        {
            CustomerId = customerId;
            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
            CustomerDetails = customerDetails;
        }

        public int CustomerId { get; }
        public CustomerDetails CustomerDetails { get; }
        public Address StartPoint { get; }
        public Address DestinationPoint { get; }
    }
}
