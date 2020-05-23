using System.Collections.Generic;
using System.Threading.Tasks;
using TransportCompany.Shared.Infrastructure.Persistence;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Infrastructure.Repository
{
    public interface IDriverRepository : IRepository<TDriver>
    {
        Task<TDriver> GetDriverWithRides(int id);
        Task<IEnumerable<TDriver>> GetAllAvailableDrivers();
    }
}
