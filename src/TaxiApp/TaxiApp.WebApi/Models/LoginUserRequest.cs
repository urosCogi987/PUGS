using TaxiApp.Application.Users.Login;

namespace TaxiApp.WebApi.Models
{
    public sealed class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand MapToLoginUserCommand()
            => new LoginUserCommand(Email, Password);
    }
}
