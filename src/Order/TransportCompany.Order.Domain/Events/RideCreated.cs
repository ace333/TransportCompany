using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Events
{
    public sealed class RideCreated : IDomainEvent
    {
        public RideCreated(int driverId,
            int customerId,
            Money price, 
            CustomerDetails customerDetails, 
            Address startPoint, 
            Address destination)
        {
            DriverId = driverId;
            CustomerId = customerId;
            Price = price;
            CustomerDetails = customerDetails;
            StartPoint = startPoint;
            Destination = destination;
        }

        public int DriverId { get; }
        public int CustomerId { get; }
        public Money Price { get; }
        public CustomerDetails CustomerDetails { get; }
        public Address StartPoint { get; }
        public Address Destination { get; }
    }
}
