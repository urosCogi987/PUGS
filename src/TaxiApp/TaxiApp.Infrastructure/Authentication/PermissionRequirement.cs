﻿using Microsoft.AspNetCore.Authorization;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permission)
            => Permission = permission;

        public string Permission { get; }
    }
}
