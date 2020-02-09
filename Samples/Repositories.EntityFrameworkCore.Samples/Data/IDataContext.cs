using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Data.Repositories;

namespace Repositories.EntityFrameworkCore.Samples.Data
{
    internal interface IDataContext : IContext
    {
        public IAppleRepository Apples { get; }

        public IBananaRepository Bananas { get; }

        public IOrangeRepository Oranges { get; }

        public IPearRepository Pears { get; }
    }
}