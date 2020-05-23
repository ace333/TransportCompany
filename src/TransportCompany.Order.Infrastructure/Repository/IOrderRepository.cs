using System.Threading.Tasks;
using TransportCompany.Shared.Infrastructure.Persistence;
using TOrder = TransportCompany.Order.Domain.Entities.Order;

namespace TransportCompany.Order.Infrastructure.Repository
{
    public interface IOrderRepository : IRepository<TOrder>
    {
        Task<TOrder> GetCurrentOrderByDriverId(int driverId);
        Task<TOrder> GetCurrentOrderByCustomerId(int customerId);
    }
}
