using TaxiApp.Application.Abstractions;

namespace TaxiApp.Persistence.Storage
{
    internal sealed class BlobService : IBlobService
    {
        public Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FileResponse> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
