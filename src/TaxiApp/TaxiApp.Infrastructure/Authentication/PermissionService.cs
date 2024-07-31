using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class PermissionService(ApplicationDbContext dbContext) : IPermissionService
    {
        public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
        {
            ICollection<Role>[] roles = await dbContext.Set<User>()
                .Include(x => x.Roles)
                .ThenInclude(x => x.Permissions)
                .Where(x => x.Id == userId)
                .Select(x => x.Roles)
                .ToArrayAsync();


            return roles
                .SelectMany(x => x)
                .SelectMany(x => x!.Permissions!)
                .Select(x => x.Name)
                .ToHashSet();            
        }
    }
}
