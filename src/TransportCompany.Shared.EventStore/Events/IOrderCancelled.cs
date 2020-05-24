using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Shared.EventStore.Events
{
    public interface IOrderCancelled
    {
        int RequestorId { get; }
        RequestorType RequestorType { get; }
        string Comments { get; }
    }
}
