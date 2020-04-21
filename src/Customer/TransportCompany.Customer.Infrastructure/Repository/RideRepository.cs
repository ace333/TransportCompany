using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public class RideRepository: Repository<Ride>, IRideRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public RideRepository(CustomerDbContext customerDbContext)
            : base(customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public IQueryable<Ride> GetRidesByCustomerId(int customerId)
            => _customerDbContext.Customers
                .Where(x => x.Id == customerId)
                .SelectMany(x => x.Rides);
    }
}
