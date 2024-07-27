using MediatR;

namespace TaxiApp.Application.Users.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(string NewPassword, string OldPassword) : IRequest;
}
