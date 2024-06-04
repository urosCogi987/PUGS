namespace TaxiApp.Domain.Entities
{
    public sealed class UserRole
    {
        private UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        public static UserRole Create(Guid userId, Guid roleId)
            => new UserRole(userId, roleId);
    }
}
