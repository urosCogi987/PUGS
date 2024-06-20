using MediatR;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class DriveRepository : Repository<Drive>, IDriveRepository
    {
        public DriveRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
