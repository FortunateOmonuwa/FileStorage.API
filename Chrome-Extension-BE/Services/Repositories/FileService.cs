using Chrome_Extension_BE.DataAccess.DataContext;
using Chrome_Extension_BE.Models;
using Chrome_Extension_BE.Models.DTO;
using Chrome_Extension_BE.Services.Interfaces;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace Chrome_Extension_BE.Services.Repositories
{
    public class FileService : IFileService
    {
        private readonly FileContext _context;
        private readonly IConfiguration _config;

        public FileService(FileContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<(byte[], string, string)> GetFileAsync(string fileId)
        {
            try
            {
                int file_Id;
                if(int.TryParse(fileId, out file_Id))
                {
                    //Check for the file using the file Id
                    var file = await _context.Files.FirstOrDefaultAsync(id => id.Id == file_Id);
                    if (file == null)
                    {
                        throw new Exception($"{ResponseService.FailedStatus} {ResponseService.FailedMessage=$"File with Id: {fileId} does not exist.Please try again"}");
                    }
                    else
                    {
                        //Include Content header
                        var contentHeader = new FileExtensionContentTypeProvider();

                        if(!contentHeader.TryGetContentType(file.FilePath, out var contentType))
                        {
                            contentType = "application/octet-stream";
                        }

                        //Read contents on the file
                        byte[] videoContent = await File.ReadAllBytesAsync(file.FilePath);
               

                        return (videoContent, contentType, Path.GetFileName(file.Name));
                    }
                }
                else
                {
                    var file = await _context.Files.FirstOrDefaultAsync(id => id.Name == fileId || id.UniqueFileName == fileId || id.FilePath == fileId);
                    if(file == null)
                    {
                        throw new Exception($"{ResponseService.FailedStatus} {ResponseService.FailedMessage = $"File with Id: {fileId} does not exist.Please try again"}");
                    }
                    else
                    {
                        var contentHeader = new FileExtensionContentTypeProvider();

                        if (!contentHeader.TryGetContentType(file.FilePath, out var contentType))
                        {
                            contentType = "application/octet-stream";
                        }

                        byte[] fileContent = await File.ReadAllBytesAsync(file.FilePath);

                        return (fileContent, contentType, Path.GetFileName(file.Name)); 
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} \n{ex.Source} \n{ex.InnerException} \n\n\n\n {ResponseService.FailedStatus}\n {ResponseService.FailedMessage}");
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    //Set file size limit
                    long sizeLimit = 50L * 1024 * 1024;

                    //Validate file size limit
                    if (file.Length > sizeLimit)
                    {
                        throw new Exception($"File size is too large. Maximum allowed size is 50mb");
                    }

                    //Get file name
                    string fileName =  file.FileName;
                    //Get extension
                    string fileExtension = Path.GetExtension(fileName);
                    //Generate unique name with Guid and file extension
                    string uniqueName = Guid.NewGuid().ToString() + fileExtension;
                    //Create file path
                    string filePath = Path.Combine(_config.GetSection("Storage:Path").Value, uniqueName);


                    //Create video object
                    FileModel newFile = new()
                    {
                        Name = fileName,
                        FilePath = filePath,
                        FileExtension = fileExtension,
                        UniqueFileName = uniqueName,
                        FileSize = ((double)file.Length / (1024 * 1024)).ToString("F2") + "MB", //Convert file size from bytes to megabytes formated to two decimal places and then to string
                        Url = $"http://fortunate3d-001-site1.atempurl.com/api/DownloadFile?fileId={uniqueName}",
                        UploadDate = DateTime.Now
                    };
                    

                    // Copy the uploaded video file to the destination folder within the wwwroot directory.

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync((Stream)stream);
                    }

                    //Add new video object to database
                    await _context.Files.AddAsync(newFile);
                    //Save changes
                    await _context.SaveChangesAsync();

                    return $"Video {newFile.Name} was successfully uploaded to {newFile.FilePath} with a unique name of {newFile.UniqueFileName}....\n\n Video can be viewed on{newFile.Url}";
                }
                else
                {
                    throw new Exception($"{ResponseService.FailedStatus} {ResponseService.FailedMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} \n{ex.Source} \n{ex.InnerException} \n\n\n\n {ResponseService.FailedStatus}\n {ResponseService.FailedMessage}");
            }
        }
    }
}
