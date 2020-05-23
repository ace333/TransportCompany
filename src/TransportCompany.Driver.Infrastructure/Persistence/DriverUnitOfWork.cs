using TransportCompany.Driver.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Persistence
{
    public class DriverUnitOfWork : UnitOfWork, IDriverUnitOfWork
    {
        public DriverUnitOfWork(DriverDbContext driverDbContext, 
            IDriverRepository driverRepository,
            IRideRequestRepository rideRequestRepository)
            : base(driverDbContext)
        {
            DriverRepository = driverRepository;
            RideRequestRepository = rideRequestRepository;
        }

        public IDriverRepository DriverRepository { get; }

        public IRideRequestRepository RideRequestRepository { get; }
    }
}
