using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.Constants;
using TaxiApp.Persistence.SeedData;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(TableNames.Roles);
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Permissions)                
                .WithMany()
                .UsingEntity<RolePermission>();

            builder.HasMany(x => x.Users)
                .WithMany();

            builder.HasData(Data._roles);
        }
    }
}
