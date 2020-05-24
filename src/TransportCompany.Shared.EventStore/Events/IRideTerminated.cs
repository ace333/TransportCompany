using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IRideTerminated
    {
        int DestinatedEntityId { get; }
        RequestorType DestinatedEntityType { get; }
    }
}
