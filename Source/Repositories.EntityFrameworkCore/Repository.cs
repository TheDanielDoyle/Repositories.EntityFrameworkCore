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
        private readonly DbContext context;

        protected Repository(DbContext context)
        {
            this.context = context;
        }

        public virtual Task AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return Task.FromResult(this.context.AddAsync(entity, cancellation));
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return this.context.AddRangeAsync(entities, cancellation);
        }

        public virtual Task<long> CountAsync(CancellationToken cancellation = default)
        {
            return this.context.Set<TEntity>().LongCountAsync(cancellation);
        }

        public virtual Task<long> CountAsync(IRepositoryQuery<TEntity> query, CancellationToken cancellation = default)
        {
            return this.context.Set<TEntity>().LongCountAsync(query.GetQuery(), cancellation);
        }

        public virtual async Task<TEntity> FindByIdAsync(TId id, CancellationToken cancellation = default)
        {
            TEntity entity = await ((DbSet<TEntity>)Hydrate(this.context.Set<TEntity>())).FindAsync(new object[] { id }, cancellation).ConfigureAwait(false);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(IRepositoryQuery<TEntity> query, CancellationToken cancellation = default)
        {
            return await query.Hydrate(Hydrate(this.context.Set<TEntity>()).Where(query.GetQuery())).ToListAsync(cancellation).ConfigureAwait(false);
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return Task.FromResult(this.context.Remove(entity));
        }

        public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return Task.FromResult(this.context.Remove(entities));
        }

        protected virtual IQueryable<TEntity> Hydrate(IQueryable<TEntity> queryable)
        {
            return queryable;
        }
    }
}
