using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Constants;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
            => !(await _dbContext.Set<User>().AnyAsync(user => user.Email == email));

        public async Task<bool> IsUsernameUniqueAsync(string username)
            => !(await _dbContext.Set<User>().AnyAsync(user => user.Username == username));               

        public async Task<User?> GetUserWithRefreshTokens(Guid id)
        {
            return await _dbContext.Set<User>()
                .AsNoTracking()
                .Include(x => x.RefreshTokens)
                .Where(x => x.Id == id)                
                .FirstOrDefaultAsync();            
        }        

        public async Task<User?> GetUserByVerificationToken(string token)
        {
            return await _dbContext.Set<VerificationToken>()
                .Where(x => x.Value == token)                
                .Select(x => x.User)                
                .FirstOrDefaultAsync();
        }            
        
        public async Task<IEnumerable<User>> GetUsersWithRoles()
        {
            return await _dbContext.Set<User>()
                .Include(x => x.Roles)
                .ToListAsync();
        }       

        public async Task<User?> GetUserWithRoles(Guid userId)
        {
            return await _dbContext.Set<User>()
                .Include(x => x.Roles)
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CanUserConfirmDrive(Guid userId, Guid driveId)
        {
            //return await _dbContext.Set<User>()
            //    .Include(x => x.DrivesPassanger)
            //    .Where(x => x.Id == userId)
            //    //.SelectMany(x => )
            //    .Where(x => x.DrivesPassanger.Any(x => x.Id == driveId))
            //    .AnyAsync();            
            return await _dbContext.Set<User>()                
                .Where(x => x.Id == userId)
                .SelectMany(x => x.DrivesPassanger)                
                .AnyAsync(dp => dp.Id == driveId);
        }

        public async Task<bool> IsUserAdmin(Guid userId)
        {
            return await _dbContext.Set<User>()
                //.Include(x => x.Roles)
                .Where(x => x.Id  == userId)
                .SelectMany(x => x.Roles)
                .AnyAsync(r => r.Name == RoleNames.Admin);                
        }
    }
}
