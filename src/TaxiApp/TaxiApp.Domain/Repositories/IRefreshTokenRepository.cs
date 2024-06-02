using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Domain.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
    }
}
