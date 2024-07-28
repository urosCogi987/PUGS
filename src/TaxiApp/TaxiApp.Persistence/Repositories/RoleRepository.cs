using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }

        public async Task<IEnumerable<Role>> GetRolesForUser(Guid userId)
        {
            return await _dbContext.Set<User>()
                .Include(x => x.Roles)
                .Where(x => x.Id == userId)
                .SelectMany(x => x.Roles)
                .ToListAsync();
        }
    }
}
