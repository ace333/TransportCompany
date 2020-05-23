using TransportCompany.Order.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Persistence
{
    public interface IOrderUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
    }
}
