using MediatR;
using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.Application.Users.Commands.SetStatus
{
    public sealed record SetUserStatusCommand(Guid Id, UserStatus UserStatus) : IRequest;    
}
