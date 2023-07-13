using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BCrypt.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace RegistrationAPI.Models
{
    public class UserRegistration
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 999)]
        public int CountryCode { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be 10 digits.")]
        public long PhoneNumber { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        // 15

        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

}
