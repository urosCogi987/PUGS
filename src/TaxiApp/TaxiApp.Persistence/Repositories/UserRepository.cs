using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

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
            => await _dbContext.Set<VerificationToken>().Where(x => x.Value == token).Select(x => x.User).FirstOrDefaultAsync();        
    }
}
