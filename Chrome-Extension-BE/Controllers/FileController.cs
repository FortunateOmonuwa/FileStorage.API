using FileStorage.API.Models;
using FileStorage.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chrome_Extension_BE.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
         

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadVideo(IFormFile file)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newFile = await _fileService.UploadFileAsync(file);
                    return Ok(newFile);
                }
                else 
                {
                    return BadRequest();
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}\n {ex.Source}\n {ex.InnerException}");
            }
        }


        [HttpGet("DownloadFile")]
        [Authorize (Roles = UserRole.User)]
        public async Task<IActionResult> DownloadVideo(string fileId)
        {
            try
            {
                var file = await _fileService.GetFileAsync(fileId);
                return File(file.Item1, file.Item2, file.Item3);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}\n {ex.Source}\n {ex.InnerException}");
            }
        }
    }
}
