using TransportCompany.Driver.Infrastructure.Repository;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Persistence
{
    public interface IDriverUnitOfWork : IUnitOfWork
    {
        IDriverRepository DriverRepository { get; }
        IRideRequestRepository RideRequestRepository { get; }
    }
}
