using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public interface IRideRepository: IRepository<Ride>
    {
        IQueryable<Ride> GetRidesByCustomerId(int customerId);
    }
}
