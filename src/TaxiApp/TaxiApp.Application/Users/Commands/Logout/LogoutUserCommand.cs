using MediatR;

namespace TaxiApp.Application.Users.Commands.Logout
{
    public sealed record LogoutUserCommand(string RefreshToken) : IRequest;
}
