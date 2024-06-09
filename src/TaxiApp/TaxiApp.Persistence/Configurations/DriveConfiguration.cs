using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class DriveConfiguration : IEntityTypeConfiguration<Drive>
    {
        public void Configure(EntityTypeBuilder<Drive> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.DriverId);
        }
    }
}
