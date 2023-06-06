using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieLibrary.ViewModels
{
    public class ProfilePageViewModel
    {
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<MovieComment>? Comments { get; set; }
        public List<Movie>? CreatedMovies { get; set; }

        [Display(Name = "New profile picture")]
        public IFormFile? NewProfilePicture { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = ("The password field is required"))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and must contain one sybol or number.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = ("This field is required"))]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The two passwords do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
