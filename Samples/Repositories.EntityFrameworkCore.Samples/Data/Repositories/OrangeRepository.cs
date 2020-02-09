using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class OrangeRepository : Repository<Orange, int>, IOrangeRepository
    {
        public OrangeRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Orange> HydrateQueryable(IQueryable<Orange> queryable)
        {
            return queryable;
        }
    }
}