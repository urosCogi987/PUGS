using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Queries.GetProfilePicture
{
    public sealed record GetProfilePictureQuery : IRequest<FileResponse>;    
}
