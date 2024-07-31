﻿using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> GetRolesForUser(Guid userId);
    }
}
