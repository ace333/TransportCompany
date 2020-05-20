using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Order.Domain.Events
{
    public class DriverRideTerminated : IDomainEvent
    {
        public DriverRideTerminated(int driverId)
        {
            DriverId = driverId;
        }

        public int DriverId { get; }
    }
}
