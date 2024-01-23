using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Chrome_Extension_BE.Models;

namespace FileStorage.API.Models
{
    public class User
    {
        [Key]
        [DisplayName("User ID")]
        public Guid UserId { get; set; }

        [DisplayName("Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username is required!")]
        [StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "The username has to be between 8 and 50 characters+")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        //public string? PasswordResetToken { get; set; }
        //public DateTime? ResetTokenExpiration
        //{
        //    get { return resetTokenExpiration; }
        //    set
        //    {
        //        resetTokenExpiration = value;
        //        if (value.HasValue && (DateTime.UtcNow - value.Value).TotalMinutes >= 10)
        //        {
        //            resetTokenExpiration = null;
        //        }
        //    }
        //}

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Role Role { get; set; } = new();
        public List<FileModel>? Files { get; set; }


        //private DateTime? resetTokenExpiration;

    }
}
