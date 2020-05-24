using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class CustomerRated : ICustomerRated
    {
        public CustomerRated(int customerId, decimal grade)
        {
            CustomerId = customerId;
            Grade = grade;
        }

        public int CustomerId { get; }
        public decimal Grade { get; }
    }
}
