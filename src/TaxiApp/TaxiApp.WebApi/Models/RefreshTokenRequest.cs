using TaxiApp.Application.Users.Refresh;

namespace TaxiApp.WebApi.Models
{
    public sealed class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }

        public RefreshTokenCommand MapToRefreshTokenCommand()
            => new RefreshTokenCommand(RefreshToken);
    }
}
