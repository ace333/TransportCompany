using TransportCompany.Driver.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Persistence
{
    public class DriverUnitOfWork : UnitOfWork, IDriverUnitOfWork
    {
        public DriverUnitOfWork(DriverDbContext driverDbContext, IDriverRepository driverRepository)
            : base(driverDbContext)
        {
            DriverRepository = driverRepository;
        }

        public IDriverRepository DriverRepository { get; }
    }
}
