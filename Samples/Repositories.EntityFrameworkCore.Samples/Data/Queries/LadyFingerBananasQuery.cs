using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Queries
{
    internal class LadyFingerBananasQuery : IRepositoryQuery<Banana>
    {
        private readonly FavouriteBananaTypes _bananaTypes;

        public LadyFingerBananasQuery(FavouriteBananaTypes bananaTypes)
        {
            _bananaTypes = bananaTypes;
        }

        public Expression<Func<Banana, bool>> GetQuery()
        {
            return banana => _bananaTypes.Types.Contains(banana.Type);
        }
    }

    internal class FavouriteBananaTypes
    {
        public FavouriteBananaTypes(params string[] favouriteBananaTypes)
        {
            Types = favouriteBananaTypes.ToList();
        }

        public IReadOnlyList<string> Types { get; }
    }
}