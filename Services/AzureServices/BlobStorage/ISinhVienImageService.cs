namespace CSharp_FinalExam.Services.AzureServices.BlobStorage;

public interface ISinhVienImageService
{
    Task<string> UploadSinhVienImageAsync(byte[] fileBytes, string fileName, string blobContainerName);
    Task<string> DownloadSinhVienImageAsync(string imageUrl, string blobContainerName);
}