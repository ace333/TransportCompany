using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Domain.Events
{
    public class OrderCreated : IOrderCreated
    {
        public OrderCreated(int customerId, 
            int driverId,
            Money price, 
            CustomerDetails customerDetails,
            DriverDetails driverDetails,
            Address startPoint,
            Address destination)
        {
            CustomerId = customerId;
            DriverId = driverId;
            Price = price;
            CustomerDetails = customerDetails;
            DriverDetails = driverDetails;
            StartPoint = startPoint;
            Destination = destination;
        }

        public int CustomerId { get; }
        public int DriverId { get; }
        public Money Price { get; }
        public CustomerDetails CustomerDetails { get; }
        public DriverDetails DriverDetails { get; }
        public Address StartPoint { get; }
        public Address Destination { get; }
    }
}
