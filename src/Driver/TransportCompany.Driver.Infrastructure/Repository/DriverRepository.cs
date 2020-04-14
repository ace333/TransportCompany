using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public class DriverRepository: IDriverRepository
    {
        private readonly DriverDbContext _driverDbContext;

        public DriverRepository(DriverDbContext driverDbContext)
        {
            _driverDbContext = driverDbContext;
        }
    }
}
