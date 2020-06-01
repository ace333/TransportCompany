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

        public IQueryable<Ride> GetFinishedRidesByCustomerId(int customerId)
            => _customerDbContext.Customers
                .Include(x => x.Rides)
                .AsNoTracking()
                .Where(x => x.Id == customerId)
                .SelectMany(x => x.Rides
                    .Where(y => new[] { RideStatus.Completed, RideStatus.Cancelled }.Contains(y.Status))
                );
    }
}
