using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Configuration
{
    internal class AppleConfiguration : IEntityTypeConfiguration<Apple>
    {
        public void Configure(EntityTypeBuilder<Apple> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
            builder.HasOne(x => x.Pip);
        }
    }
}
