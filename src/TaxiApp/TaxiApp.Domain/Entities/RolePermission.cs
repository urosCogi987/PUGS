namespace TaxiApp.Domain.Entities
{
    public sealed class RolePermission : BaseEntity
    {
        private RolePermission(Guid id, Guid roleId, Guid permissionId) : base(id)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        public Guid RoleId { get; private set; }
        public Guid PermissionId { get; private set; }

        public static RolePermission Create(Guid id, Guid roleId, Guid permissionId)
            => new RolePermission(id, roleId, permissionId);
    }
}
