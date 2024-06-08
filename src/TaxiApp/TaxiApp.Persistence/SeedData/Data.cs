using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Constants;

namespace TaxiApp.Persistence.SeedData
{
    internal static class Data
    {        
        private static Guid _headAdminId = Guid.NewGuid();        

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
            User.CreateAdmin(_headAdminId,
                        "admin",
                        "admintaxiapp@yopmail.com",
                        "w18sTtz2B0L0xtlle9xi3A==;7C7r8AaAq4VGSTzu1yE0b/WJh4PcVwlgnPxKZk6y5Ko=",
                        "admin",
                        "admin",
                        "address",
                        new DateTime(1997, 1, 19, 0, 40, 0).ToUniversalTime())
        };

        internal static List<RolePermission> _rolePermissions = new List<RolePermission>()
        {
            // Admin RolePermission seed
            RolePermission.Create(Guid.NewGuid(),
                                  _roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.RoleAdmin).Id),

            RolePermission.Create(Guid.NewGuid(),
                                  _roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id),

            RolePermission.Create(Guid.NewGuid(),
                                  _roles.First(x => x.Name == RoleNames.Admin).Id,
                                  _permissions.First(x => x.Name == PermissionNames.CanViewAllUsers).Id),

            // User RolePermission seed
            RolePermission.Create(Guid.NewGuid(),
                                  _roles.First(x => x.Name == RoleNames.User).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id),

            // Driver RolePermission seed
            RolePermission.Create(Guid.NewGuid(), 
                                  _roles.First(x => x.Name == RoleNames.Driver).Id,
                                  _permissions.First(x => x.Name == PermissionNames.TestPermission).Id)
        };

        internal static List<UserRole> _userRoles = new List<UserRole>()
        {
            UserRole.Create(Guid.NewGuid(),
                            _admins.First(x => x.Id == _headAdminId).Id,
                            _roles.First(x => x.Name == RoleNames.Admin).Id)
        };
    }
}
