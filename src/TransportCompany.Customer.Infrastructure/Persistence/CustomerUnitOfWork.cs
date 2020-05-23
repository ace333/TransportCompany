using TransportCompany.Customer.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Persistence
{
    public class CustomerUnitOfWork : UnitOfWork, ICustomerUnitOfWork
    {
        public CustomerUnitOfWork(CustomerDbContext customerDbContext,
            ICustomerRepository customerRepository, 
            IRideRepository rideRepository) : base(customerDbContext)
        {
            CustomerRepository = customerRepository;
            RideRepository = rideRepository;
        }

        public ICustomerRepository CustomerRepository { get; }
        public IRideRepository RideRepository { get; }
    }
}
