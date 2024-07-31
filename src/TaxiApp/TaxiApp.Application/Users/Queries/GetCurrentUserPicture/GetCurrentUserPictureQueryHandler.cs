using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Users.Queries.GetCurrentUserPicture;

namespace TaxiApp.Application.Users.Queries.GetProfilePicture
{
    internal sealed class GetCurrentUserPictureQueryHandler(
        IBlobService blobService,
        IUserContext userContext) : IRequestHandler<GetCurrentUserPictureQuery, FileResponse>
    {
        public async Task<FileResponse> Handle(GetCurrentUserPictureQuery request, CancellationToken cancellationToken)
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
