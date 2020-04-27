using System;
using Repositories.EntityFrameworkCore.Samples.Data.Queries;

namespace Repositories.EntityFrameworkCore.Samples.Models
{
    internal class Apple
    {
        public Apple()
        {
        }

        public Apple(string type)
        {
            Type = type;
        }

        public Guid Id { get; set; }

        public ApplePip Pip { get; set; }

        public string Type { get; set; }
    }
}