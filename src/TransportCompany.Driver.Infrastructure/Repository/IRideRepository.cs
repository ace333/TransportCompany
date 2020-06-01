using System.Linq;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public interface IRideRepository : IRepository<Ride>
    {
        IQueryable<Ride> GetAllCompletedRidesByDriverId(int driverId);
    }
}
