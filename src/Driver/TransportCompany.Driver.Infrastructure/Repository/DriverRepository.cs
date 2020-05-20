using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public class DriverRepository: Repository<TDriver>, IDriverRepository
    {
        private readonly DriverDbContext _driverDbContext;

        public DriverRepository(DriverDbContext driverDbContext)
            : base(driverDbContext)
        {
            _driverDbContext = driverDbContext;
        }

        public async Task<IEnumerable<TDriver>> GetAllAvailableDrivers()
            => await _driverDbContext.Drivers
            .Include(x => x.Rides)
            .Where(x => x.Rides.All(y => y.Status == RideStatus.Completed))
            .ToListAsync();

        public async Task<TDriver> GetDriverWithRides(int id)
            => await _driverDbContext.Drivers
            .Include(x => x.Rides)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
    }
}
