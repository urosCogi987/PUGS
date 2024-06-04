using MediatR;
using TaxiApp.Application.Dtos;

namespace TaxiApp.Application.Users.Login
{
    public sealed record LoginUserCommand(string Email, string Password) : IRequest<TokensDto>;
}
