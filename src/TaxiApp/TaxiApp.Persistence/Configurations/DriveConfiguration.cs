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

            builder.HasOne(x => x.User)
                .WithMany(y => y.DrivesPassanger)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Driver)
                .WithMany(y => y.DrivesDriver)
                .HasForeignKey(x => x.DriverId);

            //builder.HasIndex(x => x.UserId);
            //builder.HasIndex(x => x.DriverId);
        }
    }
}
