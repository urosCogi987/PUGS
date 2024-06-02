using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.Constants;
using TaxiApp.Persistence.SeedData;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(TableNames.Permissions);

            builder.HasKey(x => x.Id);

            builder.HasData(Data._permissions);
        }
    }
}
