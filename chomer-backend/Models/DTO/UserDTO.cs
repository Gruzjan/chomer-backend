using System.ComponentModel.DataAnnotations;

namespace chomer_backend.Models.DTO
{
    public class CreateUserDTO : LoginUserDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    public class LoginUserDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
    public class UpdateUserDTO
    {
        [StringLength(100, ErrorMessage = "Username must be between {2} and {1} characters.", MinimumLength = 2)]
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
        [MinLength(8)]
        public string? Password { get; set; }
    }
    public class UserDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
        public virtual IList<House> Houses { get; set; }
        public virtual IList<HouseUser> HouseUsers { get; set; }
    }
}
