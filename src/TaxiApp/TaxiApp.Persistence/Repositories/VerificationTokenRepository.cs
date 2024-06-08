using MediatR;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class VerificationTokenRepository : Repository<VerificationToken>, IVerificationTokenRepository
    {
        public VerificationTokenRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
