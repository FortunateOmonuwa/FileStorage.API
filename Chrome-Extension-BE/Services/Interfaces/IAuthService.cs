using FileStorage.API.Models.DTO;

namespace FileStorage.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseModel<string>> Register(UserCreateDTO register_model);
        Task<ResponseModel<string>> Login(UserLoginDTO login_model);
        Task<ResponseModel<string>> VerifyUser(string token);
        Task<string> ForgotPassword(ForgotPasswordDTO email);
        Task<string> VerifyResetToken(string token);
        Task<string> ResetPassword(PasswordResetDTO reset);
    }
}
