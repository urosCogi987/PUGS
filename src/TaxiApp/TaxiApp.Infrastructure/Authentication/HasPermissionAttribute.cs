using Microsoft.AspNetCore.Authorization;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) : base(policy: permission)
        {
        }
    }
}
