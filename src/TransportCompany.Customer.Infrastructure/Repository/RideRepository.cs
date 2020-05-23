using Microsoft.EntityFrameworkCore;
using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Customer.Domain.Enums;
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

        // TO DO: change to customer repository or smth
        public IQueryable<Ride> GetFinishedRidesByCustomerId(int customerId)
            => _customerDbContext.Customers
                .Include(x => x.Rides)
                .Where(x => x.Id == customerId)
                .SelectMany(x => x.Rides.Where(y => y.Status == RideStatus.Completed));
    }
}
