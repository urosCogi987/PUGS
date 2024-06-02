﻿using Microsoft.EntityFrameworkCore;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
            => !(await _dbContext.Set<User>().AnyAsync(user => user.Email == email));

        public async Task<bool> IsUsernameUniqueAsync(string username)
            => !(await _dbContext.Set<User>().AnyAsync(user => user.Username == username));
    }
}