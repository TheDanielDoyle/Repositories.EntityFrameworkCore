using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class BananaRepository : Repository<Banana, int>, IBananaRepository
    {
        public BananaRepository(DbContext context) : base(context)
        {
        }

        protected override Expression<Func<Banana, bool>> GetEquality(int id)
        {
            return (banana) => banana.Id == id;
        }

        protected override IQueryable<Banana> ProjectTo(IQueryable<Banana> queryable)
        {
            return queryable;
        }
    }
}