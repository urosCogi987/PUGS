using MediatR;

namespace TaxiApp.Application.Users.Logout
{
    public sealed record LogoutUserCommand(string RefreshToken) : IRequest;    
}
