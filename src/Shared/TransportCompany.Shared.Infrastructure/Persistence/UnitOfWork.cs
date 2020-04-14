﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public abstract class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _dbContext;

        protected UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit() => _dbContext.SaveChanges();

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public async Task<TEntity> FindAsync<TKey, TEntity>(TKey key) where TEntity : Entity
            => await _dbContext.FindAsync<TEntity>(key);

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
            => _dbContext.Add(entity);

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
            => _dbContext.Remove(entity);
    }
}
