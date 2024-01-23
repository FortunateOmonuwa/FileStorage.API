using FileStorage.API.Models.DTO;
using FileStorage.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }


        [HttpPost("Register-new-user")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO registerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    var user = await authService.Register(registerModel);
                    if (user.IsSuccessful)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest(user);
                    }
                }
            }
            catch(Exception ex) 
            {
                //throw new BadHttpRequestException("An error occured", StatusCodes.Status400BadRequest);
                throw new Exception($"{ex.Source} \n {ex.InnerException} \n {ex.Data} \n {ex.Message}");
            }
        }
    }
}
