using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _dbContext;

        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> FindAsync<TKey>(TKey id)
            => await _dbContext.Set<TEntity>().FindAsync(id);

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
