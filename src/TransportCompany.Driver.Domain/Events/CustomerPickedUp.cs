using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class CustomerPickedUp : ICustomerPickedUp
    {
        public CustomerPickedUp(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}
