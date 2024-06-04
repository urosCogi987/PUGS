using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class PermissionService(ApplicationDbContext dbContext) : IPermissionService
    {
        public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
        {
            List<ICollection<Permission>> roles = await dbContext.Set<Role>()
                            .Include(x => x.Users)
                            .Where(x => x.Users.Any(y => y.Id == userId))
                            .Select(x => x.Permissions).ToListAsync();

            HashSet<string> permissionHashSet = new();            
            
            foreach (var role in roles)
            {
                foreach (var permission in role)
                {
                    permissionHashSet.Add(permission.Name);                    
                }
            }
            
            return permissionHashSet;
        }
    }
}
