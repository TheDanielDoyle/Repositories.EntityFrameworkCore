using System;

namespace Repositories.EntityFrameworkCore.Samples.Models
{
    internal class Orange
    {
        public Orange()
        {
        }

        public Orange(string type)
        {
            Type = type;
        }

        public Guid Id { get; set; }

        public string Type { get; set; }
    }
}
