using TransportCompany.Customer.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
    }
}
