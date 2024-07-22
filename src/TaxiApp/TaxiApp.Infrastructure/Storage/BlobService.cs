using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Persistence.Storage
{
    public sealed class BlobService(BlobServiceClient blobServiceClient) : IBlobService
    {
        private const string containerName = "profile-pictures";

        public async Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }

        public async Task<FileResponse> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            Azure.Response<BlobDownloadResult> response = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);

            return new FileResponse(response.Value.Content.ToStream(), response.Value.Details.ContentType); // can be null
        }

        public async Task<Guid> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var fileId = Guid.NewGuid();
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.UploadAsync(
                stream,
                new BlobHttpHeaders { ContentType = contentType }, 
                cancellationToken: cancellationToken);

            return fileId;
        }
    }
}
