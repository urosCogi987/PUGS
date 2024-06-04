using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class PermissionAuthorizationHandler(IServiceProvider serviceProvider) 
        : AuthorizationHandler<PermissionRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            string? userId = context.User.Claims.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userId, out Guid parsedUserId))
                return;

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();
                HashSet<string> permissions = await permissionService.GetPermissionsAsync(parsedUserId);

                if (permissions.Contains(requirement.Permission))
                    context.Succeed(requirement);
            }            
        }
    }
}
