using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RideCancelled : IDomainEvent
    {
        public RideCancelled(int customerId, string comments)
        {
            CustomerId = customerId;
            Comments = comments;
        }        

        public int CustomerId { get; }
        public string Comments { get; }
    }
}
