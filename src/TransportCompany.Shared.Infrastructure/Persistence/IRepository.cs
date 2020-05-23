using System.Linq;
using System.Threading.Tasks;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public interface IRepository<TEntity> : IScopedService where TEntity : Entity
    {
        Task<TEntity> FindAsync<TKey>(TKey id);
        IQueryable<TEntity> GetAll();
    }
}
