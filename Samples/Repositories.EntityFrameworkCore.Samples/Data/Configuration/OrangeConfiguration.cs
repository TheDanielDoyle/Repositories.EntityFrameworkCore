using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Configuration
{
    internal class OrangeConfiguration : IEntityTypeConfiguration<Orange>
    {
        public void Configure(EntityTypeBuilder<Orange> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
        }
    }
}