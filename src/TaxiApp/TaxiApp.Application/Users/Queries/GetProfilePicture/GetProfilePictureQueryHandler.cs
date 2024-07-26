using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Queries.GetProfilePicture
{
    internal sealed class GetProfilePictureQueryHandler(
        IBlobService blobService,
        IUserContext userContext) : IRequestHandler<GetProfilePictureQuery, FileResponse>
    {
        public async Task<FileResponse> Handle(GetProfilePictureQuery request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated.");
            }                
            
            var file = await blobService.DownloadAsync(userContext.UserId);
            if (file == null)
            {
                file = await blobService.DownloadAsync(Guid.Empty);
            }

            return file;
        }
    }
}
