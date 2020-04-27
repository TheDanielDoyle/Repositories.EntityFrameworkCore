using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.EntityFrameworkCore.Samples.Data.Queries;

namespace Repositories.EntityFrameworkCore.Samples.Data.Configuration
{
    internal class ApplePipConfiguration : IEntityTypeConfiguration<ApplePip>
    {
        public void Configure(EntityTypeBuilder<ApplePip> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Size);
        }
    }
}