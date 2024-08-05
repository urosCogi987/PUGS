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
        Task<IEnumerable<User>> GetUsersWithRoles();        
        Task<User?> GetUserWithRoles(Guid userId);
        Task<bool> CanUserConfirmDrive(Guid userId, Guid driveId);
        Task<bool> IsUserAdmin(Guid userId);
    }
}
