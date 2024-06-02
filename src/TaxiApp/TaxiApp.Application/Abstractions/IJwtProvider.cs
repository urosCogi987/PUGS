using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(User user);
        string GenerateEmptyToken();
    }
}
