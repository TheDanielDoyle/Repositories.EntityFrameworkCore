using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal class AppleRepository : Repository<Apple, int>, IAppleRepository
    {
        public AppleRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Apple> ProjectTo(IQueryable<Apple> queryable)
        {
            return queryable;
        }
    }
}