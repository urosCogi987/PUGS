using MediatR;

namespace TaxiApp.Application.Users.Commands.UpdateProfile
{
    public sealed record UpdateUserProfileCommand(        
        string Username,
        string Name,
        string Surname,
        string Address,
        DateTime DateOfBirth) : IRequest;     
}
