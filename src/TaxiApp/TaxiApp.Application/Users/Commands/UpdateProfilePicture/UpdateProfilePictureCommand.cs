using MediatR;
using Microsoft.AspNetCore.Http;

namespace TaxiApp.Application.Users.Commands.UpdateProfilePicture
{
    public sealed record UpdateProfilePictureCommand(IFormFile File) : IRequest;
}
