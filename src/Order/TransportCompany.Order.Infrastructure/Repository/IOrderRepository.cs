using System.Threading.Tasks;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Repository
{
    public interface IOrderRepository : IRepository<Domain.Entities.Order>
    {
        Task<Domain.Entities.Order> GetCurrentOrderByDriverId(int driverId);
        Task<Domain.Entities.Order> GetCurrentOrderByCustomerId(int customerId);
    }
}
