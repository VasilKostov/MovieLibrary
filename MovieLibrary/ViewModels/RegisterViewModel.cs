using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage =("The firstname field is required"))]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of your name should start with upper letter and contain only letters")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = ("The lastname field is required"))]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of your name should start with upper letter and contain only letters")]
        [Display(Name = "LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = ("The age field is required"))]
        [RegularExpression("^(1[2-9]|[2-9][0-9]|1[0-4][0-9]|150)$", ErrorMessage = "You must be at least 12 years of age to create an account here.")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = ("The email field is required"))]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = ("The username field is required"))]
        [StringLength(20, ErrorMessage = "Name must not be longer than 20 symbols.")]
        [RegularExpression("^[A-Za-z0-9._]+$", ErrorMessage = "Username can only contain numbers, leters and these 2 symbols: '.' , '_'.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = ("The password field is required"))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and must contain one sybol or number.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = ("This field is required"))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two passwords do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Profile picture")]
        public IFormFile? ProfilePircture { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
