using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Models.Relations;

namespace MovieLibrary.Models.Movies
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Budget { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MinimumAge { get; set; }
        public double Rating { get; set; }
        public int UsersRated { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? AppUserEmail { get; set; }
        public string? PosterSource { get; set; }
        public bool Accepted { get; set; }
        public string? TrailerUrl { get; set; }
        [NotMapped]
        public IFormFile? PosterFile { get; set; }
        //Find how to get the role name here without the controller
        //public string? AppUserRole { get; set; }
        //Later if we delete an AppUser their created Actors and Movies must be deleted too!
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public ICollection<Movie_MovieAward> Movie_MovieAwards { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<BucketList> BucketLists { get; set; }
        [EnumDataType(typeof(MovieCategory))]
        public MovieCategory Category { get; set; }
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> AllMovieAwards { get; set; }
        [NotMapped]
        public int[] SelectedMovieAwardsIds { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AllMovieActors { get; set; }
        [NotMapped]
        public int[] SelectedMovieActorsIds { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AllProducers { get; set; }
        [NotMapped]
        public int SelectedProducerId { get; set; }

    }
}
