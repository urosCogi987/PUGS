﻿using MediatR;
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

        public async Task<List<Role>> GetRoleWithUsers() // menjaj cim stignes
        {
            return await _dbContext.Set<Role>()
                    .AsNoTracking()
                    .Include(x => x.Users)
                    .ToListAsync();
        }
    }
}
