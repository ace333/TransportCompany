using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RideRequested : IDomainEvent
    {
        public RideRequested(int customerId, Address startPoint, Address destinationPoint, CustomerDetails customerDetails)
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
