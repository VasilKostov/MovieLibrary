using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Models.Actors;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieLibrary.ViewModels.ActorViewModels
{
    public class CreateActorViewModel
    {
        [Required(ErrorMessage = ("The firstname field is required"))]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of the actor's name should start with upper letter and contain only letters")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = ("The lastname field is required"))]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [RegularExpression("^\\p{Lu}\\p{L}*$", ErrorMessage = "The first letter of the actor's lastname should start with upper letter and contain only letters")]
        [Display(Name = "LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = ("This field is required"))]
        [Display(Name = "Actor's gender")]
        public ActorGender Gender { get; set; }

        public List<SelectListItem> AllActorAwards { get; set; } = new List<SelectListItem>();
        public int[] SelectedActorAwardsIds { get; set; } = null!;
    }
}
