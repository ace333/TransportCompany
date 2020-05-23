using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Events;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Events
{
    public class OrderCreated : IDomainEvent
    {
        public OrderCreated(int customerId, 
            int driverId,
            Money price, 
            DriverDetails driverDetails,
            Address startPoint,
            Address destination)
        {
            CustomerId = customerId;
            DriverId = driverId;
            Price = price;
            DriverDetails = driverDetails;
            StartPoint = startPoint;
            Destination = destination;
        }

        public int CustomerId { get; }
        public int DriverId { get; }
        public Money Price { get; }
        public DriverDetails DriverDetails { get; }
        public Address StartPoint { get; }
        public Address Destination { get; }
    }
}
