using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class CustomerRated : IDomainEvent
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
