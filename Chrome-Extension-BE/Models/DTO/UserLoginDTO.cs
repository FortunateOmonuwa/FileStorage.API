namespace FileStorage.API.Models.DTO
{
    public record UserLoginDTO(
          string UsernameOrEmail,
          string Password);

}
