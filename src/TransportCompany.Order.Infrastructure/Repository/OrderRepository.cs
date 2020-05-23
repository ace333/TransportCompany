using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Enums;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;
using TOrder = TransportCompany.Order.Domain.Entities.Order;

namespace TransportCompany.Order.Infrastructure.Repository
{
    public class OrderRepository: Repository<TOrder>, IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext) 
            : base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<TOrder> GetCurrentOrderByCustomerId(int customerId)
        {
            return await _orderDbContext.Orders.Where(x => x.CustomerId == customerId && x.Status == OrderStatus.Started)
                .SingleOrDefaultAsync();
        }

        public async Task<TOrder> GetCurrentOrderByDriverId(int driverId)
        {
            return await _orderDbContext.Orders.Where(x => x.DriverId == driverId && x.Status == OrderStatus.Started)
                .SingleOrDefaultAsync();
        }
    }
}
