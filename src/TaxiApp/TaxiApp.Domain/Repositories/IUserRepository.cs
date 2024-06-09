using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsUsernameUniqueAsync(string username);
        Task<User?> GetUserWithRefreshTokens(Guid id);
        Task<User?> GetUserByVerificationToken(string token);
    }
}
