namespace TaxiApp.Domain.Entities
{
    public sealed class RolePermission
    {
        private RolePermission(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        public Guid RoleId { get; private set; }
        public Guid PermissionId { get; private set; }

        public static RolePermission Create(Guid roleId, Guid permissionId)
            => new RolePermission(roleId, permissionId);
    }
}
