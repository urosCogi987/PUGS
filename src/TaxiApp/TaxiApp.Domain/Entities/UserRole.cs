namespace TaxiApp.Domain.Entities
{
    public sealed class UserRole : BaseEntity
    {
        private UserRole(Guid id, Guid userId, Guid roleId) : base(id)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        public static UserRole Create(Guid id, Guid userId, Guid roleId)
            => new UserRole(id, userId, roleId);
    }
}
