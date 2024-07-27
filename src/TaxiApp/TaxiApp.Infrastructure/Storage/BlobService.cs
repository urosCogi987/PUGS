using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Persistence.Storage
{
    public sealed class BlobService(BlobServiceClient blobServiceClient, IConfiguration configuration) : IBlobService
    {
        private readonly string containerName = configuration["Container-name"]!;

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
            
            if (!await blobClient.ExistsAsync())
            {
                return null;
            }

            Azure.Response<BlobDownloadResult> response = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);

            return new FileResponse(ConvertStreamToBase64(response.Value.Content.ToStream()), response.Value.Details.ContentType);
        }

        public async Task<string> UploadAsync(Stream stream, string contentType, Guid userId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            string pictureName = userId.ToString();
            BlobClient blobClient = containerClient.GetBlobClient(pictureName);

            await blobClient.UploadAsync(
                stream,
                new BlobHttpHeaders { ContentType = contentType }, 
                cancellationToken: cancellationToken);

            return pictureName;
        }

        private static string ConvertStreamToBase64(Stream stream)
        {
            if (stream == null || !stream.CanRead)
            {
                throw new ArgumentException("Stream is either null or unreadable.");
            }
            
            byte[] byteArray;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                byteArray = memoryStream.ToArray();
            }
            
            return Convert.ToBase64String(byteArray);
        }
    }
}
