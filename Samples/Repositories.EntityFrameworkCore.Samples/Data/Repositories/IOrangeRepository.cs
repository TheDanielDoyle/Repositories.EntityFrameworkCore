using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal interface IOrangeRepository : IRepository<Orange, int>
    {
    }
}