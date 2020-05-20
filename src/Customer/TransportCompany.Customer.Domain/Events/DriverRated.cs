using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Customer.Domain.Events
{
    public class DriverRated : IDomainEvent
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
