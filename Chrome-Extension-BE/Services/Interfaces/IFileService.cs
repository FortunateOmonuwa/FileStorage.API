namespace Chrome_Extension_BE.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<(byte[], string, string)> GetFileAsync(string fileId);
    }
}
