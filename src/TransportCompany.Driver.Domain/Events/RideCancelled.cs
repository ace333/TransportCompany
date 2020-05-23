using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Driver.Domain.Events
{
    public sealed class RideCancelled : IDomainEvent
    {
        public RideCancelled(int driverId)
        {
            DriverId = driverId;
        }        

        public int DriverId { get; }
    }
}
