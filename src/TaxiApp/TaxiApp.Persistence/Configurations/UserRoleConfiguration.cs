using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.SeedData;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new {x.UserId, x.RoleId}).IsUnique();            

            builder.HasData(Data._userRoles);
        }
    }
}
