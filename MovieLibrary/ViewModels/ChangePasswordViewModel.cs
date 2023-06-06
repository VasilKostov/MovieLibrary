using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieLibrary.ViewModels
{
    public class ChangePasswordViewModel:ProfilePageViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage =
        "The new sword and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
