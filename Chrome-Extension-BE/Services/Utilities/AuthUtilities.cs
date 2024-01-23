using BCrypt.Net;
using System.Security.Cryptography;
namespace FileStorage.API.Services.Utilities
{
    public static class AuthUtilities
    {
        public static string CreatePasswordHash(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException(nameof(password));
                }
                else
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                    return passwordHash;
                }
            }
            catch (BcryptAuthenticationException ex)
            {
                throw new BcryptAuthenticationException($"{ex.Message} \n {ex.Source} \n {ex.InnerException}");
            }
        }

        public static string CreateRandomToken()
        {
            string token = Convert.ToHexString(RandomNumberGenerator.GetBytes(8));
            return token;
        }
    }
}
