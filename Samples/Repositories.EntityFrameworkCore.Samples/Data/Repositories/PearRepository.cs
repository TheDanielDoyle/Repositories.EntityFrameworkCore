using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class PearRepository : Repository<Pear, string>, IPearRepository
    {
        public PearRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Pear> ProjectTo(IQueryable<Pear> queryable)
        {
            return queryable;
        }
    }
}