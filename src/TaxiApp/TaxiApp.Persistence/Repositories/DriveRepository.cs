using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class DriveRepository : Repository<Drive>, IDriveRepository
    {
        public DriveRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }

        public async Task<Drive?> GetDriveWithUsers(Guid id)
        {
            return await _dbContext.Set<Drive>()
                .Include(x => x.User)
                .Include(x => x.Driver)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Drive>> GetNewDrives()
        {
            return await _dbContext.Set<Drive>()
                .Include(x => x.User)
                .Where(x => x.Status == DriveStatus.UserConfirmed)
                .ToListAsync();
        }
    }
}
