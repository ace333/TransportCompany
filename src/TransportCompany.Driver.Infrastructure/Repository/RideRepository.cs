using System.Linq;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public class RideRepository : Repository<Ride>, IRideRepository
    {
        private readonly DriverDbContext _driverDbContext;

        public RideRepository(DriverDbContext driverDbContext) : base(driverDbContext)
        {
            _driverDbContext = driverDbContext;
        }

        public IQueryable<Ride> GetAllCompletedRidesByDriverId(int driverId)
        {
            return _driverDbContext.Drivers
                .Include(x => x.Rides)
                    .ThenInclude(y => y.Stops)
                .AsNoTracking()
                .Where(x => x.Id == driverId)
                .SelectMany(x => x.Rides
                    .Where(y => new[] { RideStatus.Completed, RideStatus.Cancelled }.Contains(y.Status))
                );
        }
    }
}
