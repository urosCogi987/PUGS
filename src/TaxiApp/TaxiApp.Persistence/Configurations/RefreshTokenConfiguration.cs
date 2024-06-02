using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.Constants;

namespace TaxiApp.Persistence.Configurations
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable(TableNames.RefreshTokens);

            builder.HasKey(x => x.Id);
        }
    }
}
