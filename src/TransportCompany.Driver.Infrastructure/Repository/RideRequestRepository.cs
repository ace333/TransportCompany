using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public class RideRequestRepository : Repository<RideRequest>, IRideRequestRepository
    {
        private readonly DriverDbContext _driverDbContext;

        public RideRequestRepository(DriverDbContext driverDbContext) 
            : base(driverDbContext)
        {
            _driverDbContext = driverDbContext;
        }
    }
}
