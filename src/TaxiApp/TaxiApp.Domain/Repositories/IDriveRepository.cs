using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Domain.Repositories
{
    public interface IDriveRepository : IRepository<Drive>
    {
        Task<Drive?> GetDriveWithUsers(Guid id);
        Task<IEnumerable<Drive>> GetNewDrives();
    }
}
