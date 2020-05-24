using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Domain.Events
{
    public class RideTerminated : IRideTerminated
    {
        public RideTerminated(int driverId, RequestorType destinatedEntityType)
        {
            DestinatedEntityId = driverId;
            DestinatedEntityType = destinatedEntityType;
        }       

        public int DestinatedEntityId { get; }
        public RequestorType DestinatedEntityType { get; }
    }
}
