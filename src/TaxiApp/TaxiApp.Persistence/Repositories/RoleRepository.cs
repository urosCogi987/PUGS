using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
