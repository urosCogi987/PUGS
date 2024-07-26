namespace TaxiApp.Application.Abstractions
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream stream, string contentType, Guid userId, CancellationToken cancellationToken = default);
        Task<FileResponse> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid fileId, CancellationToken cancellationToken= default);
    }
}
