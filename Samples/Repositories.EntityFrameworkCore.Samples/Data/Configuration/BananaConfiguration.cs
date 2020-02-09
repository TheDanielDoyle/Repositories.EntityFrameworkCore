using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Configuration
{
    internal class BananaConfiguration : IEntityTypeConfiguration<Banana>
    {
        public void Configure(EntityTypeBuilder<Banana> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
        }
    }
}