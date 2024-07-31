using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Queries.GetUserPicture
{
    public sealed record GetUserPictureQuery(Guid Id) : IRequest<FileResponse>;    
}
