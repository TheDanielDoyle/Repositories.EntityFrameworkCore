using System;

namespace Repositories.EntityFrameworkCore.Samples.Data.Queries
{
    internal class ApplePip
    {
        public ApplePip()
        {
        }

        public ApplePip(Guid id, int size)
        {
            Id = id;
            Size = size;
        }

        public Guid Id { get; set; }

        public int Size { get; set; }
    }
}