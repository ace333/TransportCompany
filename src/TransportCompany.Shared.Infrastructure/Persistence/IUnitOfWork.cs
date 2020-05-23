using System;
using System.Threading.Tasks;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public interface IUnitOfWork : IScopedService, IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Add<TEntity>(TEntity entity) where TEntity: Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    }
}
