using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Enums;
using TaxiApp.Kernel.Constants;

namespace TaxiApp.Persistence.SeedData
{
    internal static class Data
    {
        internal static List<Role> _roles = new List<Role>()
        {
            Role.Create(Guid.NewGuid(), RoleNames.Admin),
            Role.Create(Guid.NewGuid(), RoleNames.User),
            Role.Create(Guid.NewGuid(), RoleNames.Driver)
        };

        internal static List<Permission> _permissions = new List<Permission>()
        {
            Permission.Create(Guid.NewGuid(), PermissionNames.CanViewAllUsers),
            Permission.Create(Guid.NewGuid(), PermissionNames.RoleAdmin),
            Permission.Create(Guid.NewGuid(), PermissionNames.TestPermission)
        };

        internal static List<User> _admins = new List<User>()
        {
            User.Create(Guid.NewGuid(),
                        "admin",
                        "admin@admin.com",
                        "password12345",
                        "admin",
                        "admin",
                        "address",
                        DateTime.UtcNow,
                        UserRole.Admin)
        };

        internal static List<RolePermission> RolePermissions = new List<RolePermission>()
        {
            // Admin RolePermission seed
            RolePermission.Create(_roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.RoleAdmin).Id),

            RolePermission.Create(_roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id),

            RolePermission.Create(_roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.CanViewAllUsers).Id),

            // User RolePermission seed
            RolePermission.Create(_roles.First(x => x.Name == RoleNames.User).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id),

            // Driver RolePermission seed
            RolePermission.Create(_roles.First(x => x.Name == RoleNames.Driver).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id)
        };
    }
}
