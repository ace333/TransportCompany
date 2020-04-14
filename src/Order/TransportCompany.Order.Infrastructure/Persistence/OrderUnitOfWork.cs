using TransportCompany.Order.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Persistence
{
    public class OrderUnitOfWork : UnitOfWork, IOrderUnitOfWork
    {
        public OrderUnitOfWork(OrderDbContext orderDbContext, 
            IOrderRepository orderRepository) 
            : base(orderDbContext)
        {
            OrderRepository = orderRepository;
        }

        public IOrderRepository OrderRepository { get; }
    }
}
