using System.Threading.Tasks;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        Task<TEntity> FindAsync<TKey, TEntity>(TKey key) where TEntity : Entity;
        void Add<TEntity>(TEntity entity) where TEntity: Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    }
}
