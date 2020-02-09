using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Samples.Data.Repositories;

namespace Repositories.EntityFrameworkCore.Samples.Data
{
    internal class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Apples = new AppleRepository(this);
            Bananas = new BananaRepository(this);
            Oranges = new OrangeRepository(this);
            Pears = new PearRepository(this);
        }

        public IAppleRepository Apples { get; }

        public IBananaRepository Bananas { get; }

        public IOrangeRepository Oranges { get; }

        public IPearRepository Pears { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
