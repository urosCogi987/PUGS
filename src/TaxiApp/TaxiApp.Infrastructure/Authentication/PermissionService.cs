using TaxiApp.Persistence;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class PermissionService(ApplicationDbContext dbContext) : IPermissionService
    {
        public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
        {
            return new HashSet<string> { "TestPermission" };
        }
    }
}
