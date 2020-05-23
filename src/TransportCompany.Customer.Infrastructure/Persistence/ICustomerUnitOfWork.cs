using TransportCompany.Customer.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Persistence
{
    public interface ICustomerUnitOfWork : IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IRideRepository RideRepository { get; }
    }
}
