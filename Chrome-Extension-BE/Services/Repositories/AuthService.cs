using Chrome_Extension_BE.DataAccess.DataContext;
using FileStorage.API.Models;
using FileStorage.API.Models.DTO;
using FileStorage.API.Services.Interfaces;
using FileStorage.API.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FileStorage.API.Services.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext dbcontext;
        private readonly DbAccessUtillity dbAccessUtillity;
        public AuthService(AppDBContext dBContext, DbAccessUtillity dbAccessUtillity)
        {
            this.dbcontext = dBContext;
            this.dbAccessUtillity = dbAccessUtillity;
        }
        public async Task<ResponseModel<string>> Register(UserCreateDTO register_model)
        {
            try
            {
                var entryCheck = await dbAccessUtillity.CheckUserCreationEntry(register_model);
            
                    var passwordHash = AuthUtilities.CreatePasswordHash(register_model.Password);
                    var role = await dbcontext.Roles.FirstOrDefaultAsync(x => x.Name == "User") ?? new() { Name = UserRole.User };
                    var newUser = EntityCreationHelper.CreateUser(register_model, passwordHash, role);

                 
                    await dbcontext.Users.AddAsync(newUser);
                   // await dbcontext.Roles.AddRangeAsync(role);
                    await dbcontext.SaveChangesAsync();

                    ResponseModel<string> response = ResponseUtility.CreateSuccessResponse<string>(newUser.VerificationToken, "Registration successful. Please check your inbox for your verification token to verify your account");
                    return response;
             
            }
            catch(Exception ex)
            {

                throw new Exception($"{ex.InnerException}  \n {ex.Data} \n {ex.Source} \n {ex.Message}");
            }
        }
      
        public async Task<ResponseModel<string>> VerifyUser(string token)
        {
            try
            {
                var verifyStatus = await dbAccessUtillity.VerifyUser(token);
                return verifyStatus;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.InnerException}  \n {ex.Data} \n {ex.Source} \n {ex.Message}");
            }
        }
        public Task<ResponseModel<string>> Login(UserLoginDTO login_model)
        {
            throw new NotImplementedException();
        }

        public Task<string> ForgotPassword(ForgotPasswordDTO email)
        {
            throw new NotImplementedException();
        }

        public Task<string> ResetPassword(PasswordResetDTO reset)
        {
            throw new NotImplementedException();
        }

        public Task<string> VerifyResetToken(string token)
        {
            throw new NotImplementedException();
        }

      
    }
}
