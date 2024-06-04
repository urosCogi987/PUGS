namespace TaxiApp.Domain.Entities
{
    public sealed class Role : BaseEntity
    {
        private Role(Guid id, string name) : base(id)        
            => Name = name;
        
        public string Name { get; private set; }

        public ICollection<Permission> Permissions {  get; private set; }
        public ICollection<User> Users { get; private set; }

        public static Role Create(Guid id, string name)
            => new Role(id, name);
    }
}
