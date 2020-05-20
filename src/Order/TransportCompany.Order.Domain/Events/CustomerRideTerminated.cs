using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Order.Domain.Events
{
    public class CustomerRideTerminated : IDomainEvent
    {
        public CustomerRideTerminated(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}
