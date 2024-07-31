using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Queries.GetUserPicture
{
    internal sealed class GetUserPictureQueryHandler(
        IBlobService blobService) : IRequestHandler<GetUserPictureQuery, FileResponse>
    {
        public async Task<FileResponse> Handle(GetUserPictureQuery request, CancellationToken cancellationToken)
        {
            var file = await blobService.DownloadAsync(request.Id);
            if (file == null)
            {
                file = await blobService.DownloadAsync(Guid.Empty);
            }

            return file;
        }
    }
}
