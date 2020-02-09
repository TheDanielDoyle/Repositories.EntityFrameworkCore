using System;

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

        public string Type { get; set; }
    }
}