using System;
using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal interface IAppleRepository : IRepository<Apple, Guid>
    {
    }
}