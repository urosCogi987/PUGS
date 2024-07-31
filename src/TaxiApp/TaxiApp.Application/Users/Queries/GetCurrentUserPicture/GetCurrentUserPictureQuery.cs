using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Queries.GetCurrentUserPicture
{
    public sealed record GetCurrentUserPictureQuery : IRequest<FileResponse>;    
}
