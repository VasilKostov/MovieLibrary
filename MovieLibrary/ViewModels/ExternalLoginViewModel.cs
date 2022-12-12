using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.ViewModels
{
    public class ExternalLoginViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
