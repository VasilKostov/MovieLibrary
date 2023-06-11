using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Actors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieLibrary.ViewModels.MovieViewModels
{
    public class UpdateMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<MovieAward> Awards { get; set; }
        public List<Actor> Actors { get; set; }
        public Producer Producer { get; set; }

        public List<SelectListItem> AllMovieAwards { get; set; }
        public int[]? SelectedMovieAwardsIds { get; set; }

        public List<SelectListItem> AllMovieActors { get; set; }
        public int[]? SelectedMovieActorsIds { get; set; }

        public List<SelectListItem> AllProducers { get; set; }
        public int? SelectedMovieProducerId { get; set; }
    }
}
