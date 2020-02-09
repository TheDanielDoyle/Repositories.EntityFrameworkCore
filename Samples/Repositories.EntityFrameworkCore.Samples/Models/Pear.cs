using System;

namespace Repositories.EntityFrameworkCore.Samples.Models
{
    internal class Pear
    {
        public Pear()
        {
        }

        public Pear(Guid id, string type)
        {
            Id = id.ToString();
            Type = type;
        }

        public string Id { get; set; }

        public string Type { get; set; }
    }
}