using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public class DriverRated : IDriverRated
    {
        public DriverRated(int driverId, decimal grade)
        {
            Grade = grade;
            DriverId = driverId;
        }

        public int DriverId { get; }
        public decimal Grade { get; }
    }
}
