using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.SeedData;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => new {x.RoleId, x.PermissionId});

            builder.HasData(Data.RolePermissions);
        }
    }
}
