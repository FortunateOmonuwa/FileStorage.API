using Chrome_Extension_BE.DataAccess.DataContext;
using FileStorage.API.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace FileStorage.API.Services.Utilities
{
    public class DbAccessUtillity
    {
        private readonly AppDBContext dbcontext;

        public DbAccessUtillity(AppDBContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }
        public async Task<ResponseModel<bool>> CheckUserCreationEntry(UserCreateDTO create_model)
        {

            var entry = await dbcontext.Users.AnyAsync(u => u.Username == create_model.Username || u.Email == create_model.Email);
            if (entry == true)
            {
                ResponseModel<bool> response = ResponseUtility.CreateErrorResponse<bool>("User already exists");
                throw new DuplicateNameException($"{response}");
            }

            else if(Helper_Methods.ConfirmRegex(create_model.Username, "^[a-zA-Z0-9]+$") || Helper_Methods.ConfirmRegex(create_model.Password, "^[a-zA-Z0-9]+$") )
            {
                ResponseModel<bool> response = ResponseUtility.CreateErrorResponse<bool>("Input can only contain numbers and letter. No white space or other characters allowed");
                throw new Exception($"{response}");
            }
            else
            {
                ResponseModel<bool> response = ResponseUtility.CreateSuccessResponse(true);
                return response;
            }
        }

        public async Task<ResponseModel<string>> VerifyUser(string token_to_verify)
        {
            var token = await dbcontext.Users.SingleOrDefaultAsync(u => u.VerificationToken == token_to_verify);
            
            if(token is null)
            {
                var response = ResponseUtility.CreateErrorResponse<string>("Your verification token is invalid. Please check and try again");
                return response;
            }
            else
            {
                token.VerifiedAt = DateTime.Now;
                token.VerificationToken = string.Empty;
                dbcontext.Update(token);
                await dbcontext.SaveChangesAsync();
                var response = ResponseUtility.CreateSuccessResponse<string>("Verification was successful");
                return response;
            }
        }
       
    }
}
