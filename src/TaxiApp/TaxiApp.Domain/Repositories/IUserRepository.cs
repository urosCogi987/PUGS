using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsEmailUniqueAsync(string index);
        Task<bool> IsUsernameUniqueAsync(string index);
        Task<User?> GetUserWithRefreshTokens(Guid id);
    }
}
