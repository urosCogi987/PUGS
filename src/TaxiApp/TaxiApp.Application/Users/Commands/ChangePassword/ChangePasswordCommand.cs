using MediatR;

namespace TaxiApp.Application.Users.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(Guid Id, string NewPassword, string OldPassword) : IRequest;
}
