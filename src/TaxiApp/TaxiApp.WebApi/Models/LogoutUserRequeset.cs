using TaxiApp.Application.Users.Logout;

namespace TaxiApp.WebApi.Models
{
    public sealed class LogoutUserRequeset
    {
        public string RefreshToken { get; set; }

        public LogoutUserCommand MapToLogoutUserCommand()
            => new LogoutUserCommand(RefreshToken);
    }
}
