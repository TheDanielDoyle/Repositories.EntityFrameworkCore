using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;

namespace Repositories.EntityFrameworkCore
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> HydrateQueryable(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        public virtual Task AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return Task.FromResult(_context.AddAsync(entity, cancellation));
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return _context.AddRangeAsync(entities, cancellation);
        }

        public virtual Task<long> CountAsync(CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().LongCountAsync(cancellation);
        }

        public virtual Task<long> CountQueryAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().LongCountAsync(predicate, cancellation);
        }

        public virtual Task<long> CountQueryAsync(IRepositoryQuery<TEntity> query, CancellationToken cancellation = default)
        {
            return CountQueryAsync(query.GetQuery(), cancellation);
        }

        public virtual async Task<TEntity> FindByIdAsync(TId id, CancellationToken cancellation = default)
        {
            TEntity entity = await ((DbSet<TEntity>)HydrateQueryable(_context.Set<TEntity>())).FindAsync(new object[] { id }, cancellation);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation)
        {
            return await HydrateQueryable(_context.Set<TEntity>()).Where(predicate).ToListAsync(cancellation);
        }

        public virtual Task<IEnumerable<TEntity>> QueryAsync(IRepositoryQuery<TEntity> query, CancellationToken cancellation)
        {
            return QueryAsync(query.GetQuery(), cancellation);
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return Task.FromResult(_context.Remove(entity));
        }

        public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return Task.FromResult(_context.Remove(entities));
        }
    }
}
