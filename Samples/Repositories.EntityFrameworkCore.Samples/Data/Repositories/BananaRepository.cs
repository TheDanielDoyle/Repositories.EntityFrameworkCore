using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class BananaRepository : Repository<Banana, int>, IBananaRepository
    {
        public BananaRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Banana> Hydrate(IQueryable<Banana> queryable)
        {
            return queryable;
        }
    }
}