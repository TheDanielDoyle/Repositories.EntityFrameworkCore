using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Configuration
{
    internal class PearConfiguration : IEntityTypeConfiguration<Pear>
    {
        public void Configure(EntityTypeBuilder<Pear> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
        }
    }
}