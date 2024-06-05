using Microsoft.AspNetCore.Http;
using TaxiApp.Application.Abstractions;
using TaxiApp.Infrastructure.ExtensionMethods;

namespace TaxiApp.Infrastructure.Services
{
    public sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public bool IsAuthenticated =>
            httpContextAccessor
                .HttpContext?
                .User
                .Identity?
                .IsAuthenticated ??
            throw new ApplicationException("User context is unavailable");  

        public Guid UserId =>
            httpContextAccessor
                .HttpContext?
                .User
                .GetUserId() ??
            throw new ApplicationException("User context is unavailable");        
    }
}
