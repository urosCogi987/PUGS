using MediatR;

namespace TaxiApp.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(string Username,
                                             string Email,
                                             string Password,
                                             string Name,
                                             string Surname,
                                             string Address,
                                             DateTime DateOfBirth,
                                             string RoleName) : IRequest<Guid>;
}
