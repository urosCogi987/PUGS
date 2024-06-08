using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Domain.Entities;
using TaxiApp.Persistence.Constants;

namespace TaxiApp.Persistence.Configurations
{
    public sealed class VerificationTokenConfiguration : IEntityTypeConfiguration<VerificationToken>
    {
        public void Configure(EntityTypeBuilder<VerificationToken> builder)
        {
            builder.ToTable(TableNames.VerificationTokens);

            builder.HasKey(x => x.Id);
        }
    }
}
