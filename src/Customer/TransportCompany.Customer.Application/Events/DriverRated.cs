using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Customer.Application.Events
{
    public class DriverRated : IDomainEvent
    {
        public DriverRated(int grade)
        {
            Grade = grade;
        }

        public int Grade { get; }
    }
}
