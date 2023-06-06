using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required(ErrorMessage = ("The firstname field is required"))]
        [StringLength(20, ErrorMessage = "Name must not be longer than 20 symbols.")]
        //Doesn't work for a reason I don't understand
        //[RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of your name should start with upper letter and contain only letters.")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ("The lastname field is required"))]
        [StringLength(20, ErrorMessage = "Name must not be longer than 20 symbols.")]
        //This too
        //[RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of your name should start with upper letter and contain only letters.")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = ("The age field is required"))]
        [RegularExpression("^(1[2-9]|[2-9][0-9]|1[0-4][0-9]|150)$", ErrorMessage = "You must be at least 12 years of age to create an account here.")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = ("The username field is required"))]
        [StringLength(20, ErrorMessage = "Name must not be longer than 20 symbols.")]
        [RegularExpression("^[A-Za-z0-9._]+$", ErrorMessage = "Username can only contain numbers, leters and these 2 symbols: '.' , '_'.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = ("The email field is required"))]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Profile picture")]
        public IFormFile? ProfilePircture { get; set; }


    }
}
