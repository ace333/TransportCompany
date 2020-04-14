using TransportCompany.Order.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
    }
}
