using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public sealed class RideCancelled : IOrderCancelled
    {
        public RideCancelled(int customerId, string comments)
        {
            RequestorId = customerId;
            RequestorType = RequestorType.Customer;
            Comments = comments;
        }

        public int RequestorId { get; }
        public RequestorType RequestorType { get; }
        public string Comments { get; } 
    }
}
