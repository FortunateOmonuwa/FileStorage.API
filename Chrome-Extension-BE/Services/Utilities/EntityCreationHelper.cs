using FileStorage.API.Models;
using FileStorage.API.Models.DTO;

namespace FileStorage.API.Services.Utilities
{
    public static class EntityCreationHelper
    {
        public static User CreateUser(UserCreateDTO model, string passwordHash, Role role)
        {
            User newUser = new()
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                VerificationToken = AuthUtilities.CreateRandomToken(),
                VerifiedAt = null,
                Role = role
            };

            return  newUser;
        }


    }
}
