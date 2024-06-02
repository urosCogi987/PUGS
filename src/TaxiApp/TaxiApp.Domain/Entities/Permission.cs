namespace TaxiApp.Domain.Entities
{
    public sealed class Permission : BaseEntity
    {
        private Permission(Guid id, string name) : base(id)
            => Name = name;
        
        public string Name { get; private set; }

        public static Permission Create(Guid id, string name)
            => new Permission(id, name);
    }
}
