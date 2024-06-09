using TaxiApp.Application.Users.Commands.Login;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand MapToLoginUserCommand()
            => new LoginUserCommand(Email, Password);
    }
}
