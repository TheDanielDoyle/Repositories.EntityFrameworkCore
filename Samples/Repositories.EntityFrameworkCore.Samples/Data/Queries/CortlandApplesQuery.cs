using System;
using System.Linq;
using System.Linq.Expressions;
using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Queries
{
    internal class CortlandApplesQuery : IRepositoryQuery<Apple>
    {
        public Expression<Func<Apple, bool>> GetQuery()
        {
            return apple => apple.Type == "Cortland";
        }

        public IQueryable<Apple> Hydrate(IQueryable<Apple> entity)
        {
            return entity;
        }
    }
}
