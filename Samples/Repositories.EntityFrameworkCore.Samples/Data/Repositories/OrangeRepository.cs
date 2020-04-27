using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class OrangeRepository : Repository<Orange, Guid>, IOrangeRepository
    {
        public OrangeRepository(DbContext context) : base(context)
        {
        }

        protected override Expression<Func<Orange, bool>> GetEquality(Guid id)
        {
            return (orange) => orange.Id == id;
        }

        protected override IQueryable<Orange> ProjectTo(IQueryable<Orange> queryable)
        {
            return queryable;
        }
    }
}