using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations;


namespace MovieLibrary.ViewModels.MovieViewModels
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = ("The Title field is required"))]
        [StringLength(20, ErrorMessage = "Title is too long.")]
        [RegularExpression("^[A-Z][A-Za-z0-9\\s\\W]*$", ErrorMessage = "The first letter of your title should start with upper letter")]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = ("The budget field is required"))]
        [RegularExpression("^\\$?(\\d{1,3}(,\\d{3})*|\\d+)(\\.\\d{2})?([MmBbKk])?$", ErrorMessage = "The budget must be at leat $1. Also the dollar sign must be at the beginning!")]
        [Display(Name = "Budget")]
        public int Budget { get; set; }

        [Required(ErrorMessage = ("The release date field is required"))]
        [RegularExpression("^(19[2-9]\\d|20[0-4]\\d|2050)-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])\\s([01]\\d|2[0-3]):[0-5]\\d$", ErrorMessage = "The date must be after 1920 and till 2050!")]
        [Display(Name = "Budget")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = ("This field is required"))]
        [RegularExpression("^(?:[6-9]|[1-9][0-9]|1[01][0-9]|120)$", ErrorMessage = "The movies minimumg age are from 6 till 120 yo!")]
        [Display(Name = "Minimum age")]
        public int MinimumAge { get; set; }

        [Required(ErrorMessage = ("This field is required"))]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ("This field is required"))]
        [Display(Name = "Poster file")]
        public IFormFile Poster { get; set; } = null!;

        [Required(ErrorMessage = ("This field is required"))]
        [Display(Name = "Youtube trailer URL")]
        public string YoutubeUrl { get; set; } = null!;

        [Required(ErrorMessage = ("This field is required"))]
        [Display(Name = "Movie Genre")]
        public MovieCategory Category { get; set; }

        public List<SelectListItem>? AllMovieAwards { get; set; }
        public int[]? SelectedMovieAwardsIds { get; set; }

        public List<SelectListItem> AllMovieActors { get; set; } = new List<SelectListItem>();
        public int[] SelectedMovieActorsIds { get; set; } = null!;

        public List<SelectListItem> AllProducers { get; set; } = new List<SelectListItem>();
        public int ProducerId { get; set; }
    }
}
