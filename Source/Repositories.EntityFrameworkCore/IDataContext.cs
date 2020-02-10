using System.Threading;
using System.Threading.Tasks;

namespace Repositories.EntityFrameworkCore
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
