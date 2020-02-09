using Repositories.Abstractions;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples.Data.Repositories
{
    internal interface IPearRepository : IRepository<Pear, string>
    {
    }
}