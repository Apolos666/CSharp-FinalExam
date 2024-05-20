using Azure.Storage.Blobs;
using CSharp_FinalExam.Data;

namespace CSharp_FinalExam.Services.AzureServices.BlobStorage;

public class SinhVienImageService : ISinhVienImageService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly BlobServiceClient _blobServiceClient;
    private BlobContainerClient _blobContainerClient;

    public SinhVienImageService(
        ApplicationDbContext dbContext,
        BlobServiceClient blobServiceClient
        )
    {
        _dbContext = dbContext;
        _blobServiceClient = blobServiceClient;
    }
    
    public async Task<string> UploadSinhVienImageAsync(byte[] fileBytes, string fileName, string blobContainerName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        using var ms = new MemoryStream(fileBytes);
        await blobClient.UploadAsync(ms);
        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<string> DownloadSinhVienImageAsync(string imageUrl, string blobContainerName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
        var fileName = Uri.UnescapeDataString(new Uri(imageUrl).Segments.LastOrDefault());
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        var blobDownloadInfo = await blobClient.DownloadAsync();

        using var ms = new MemoryStream();
        await blobDownloadInfo.Value.Content.CopyToAsync(ms);
        var bytes = ms.ToArray();
        return Convert.ToBase64String(bytes);
    }
}