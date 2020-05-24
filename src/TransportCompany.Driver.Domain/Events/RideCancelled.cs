using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class RideCancelled : IOrderCancelled
    {
        public RideCancelled(int driverId)
        {
            RequestorId = driverId;
            RequestorType = RequestorType.Driver;
            Comments = "Ride has been cancelled by Driver";
        }

        public int RequestorId { get; }
        public RequestorType RequestorType { get; }
        public string Comments { get; }
    }
}
