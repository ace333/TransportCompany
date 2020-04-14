using TransportCompany.Customer.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Persistence
{
    public class CustomerUnitOfWork : UnitOfWork, ICustomerUnitOfWork
    {
        public CustomerUnitOfWork(CustomerDbContext customerDbContext,
            ICustomerRepository customerRepository) 
            : base(customerDbContext)
        {
            CustomerRepository = customerRepository;
        }

        public ICustomerRepository CustomerRepository { get; }
    }
}
