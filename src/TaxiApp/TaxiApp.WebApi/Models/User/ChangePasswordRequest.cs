using TaxiApp.Application.Users.Commands.ChangePassword;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        public ChangePasswordCommand MapToChangePasswordCommand(Guid id)
            => new ChangePasswordCommand(id, Password, OldPassword);
    }
}
