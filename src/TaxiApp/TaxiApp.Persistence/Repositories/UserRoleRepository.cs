using MediatR;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
