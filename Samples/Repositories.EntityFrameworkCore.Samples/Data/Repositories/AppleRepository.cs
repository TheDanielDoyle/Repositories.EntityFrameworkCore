using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class AppleRepository : Repository<Apple, Guid>, IAppleRepository
    {
        public AppleRepository(DbContext context) : base(context)
        {
        }

        protected override Expression<Func<Apple, bool>> GetEquality(Guid id)
        {
            return (apple) => apple.Id == id;
        }

        protected override IQueryable<Apple> ProjectTo(IQueryable<Apple> queryable)
        {
            return queryable
                .Include(x => x.Pip);
        }
    }
}