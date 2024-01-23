namespace FileStorage.API.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<(byte[], string, string)> GetFileAsync(string fileId);
    }
}
