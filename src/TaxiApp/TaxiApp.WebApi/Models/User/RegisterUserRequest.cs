using TaxiApp.Application.Users.Commands.Register;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class RegisterUserRequest : UserRequest
    {        
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }

        public RegisterUserCommand MapToRegisterUserCommand()
            => new RegisterUserCommand(Username, Email, Password, Name, Surname, Address, DateOfBirth, RoleName);
    }
}
