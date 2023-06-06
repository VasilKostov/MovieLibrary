using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;

namespace MovieLibrary.ViewModels.MovieViewModels
{
    public class CreateMovieViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Budget { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int MinimumAge { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Poster { get; set; }
        [Required]
        public string YoutubeUrl { get; set; }

        public MovieCategory Category { get; set; }

        public IEnumerable<SelectListItem> AllMovieAwards { get; set; }
        public int[] SelectedMovieAwardsIds { get; set; }

        public IEnumerable<SelectListItem> AllMovieActors { get; set; }
        public int[] SelectedMovieActorsIds { get; set; }

        public IEnumerable<SelectListItem> AllProducers { get; set; }
        public int ProducerId { get; set; }
    }
}
