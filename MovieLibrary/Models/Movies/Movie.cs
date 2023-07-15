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
        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        [EnumDataType(typeof(MovieCategory))]
        public MovieCategory Category { get; set; }

        [NotMapped]
        public IFormFile? PosterFile { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<MovieComment> MovieComments { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public List<Movie_MovieAward> Movie_MovieAwards { get; set; }
        public List<Favourite> Favourites { get; set; }
        public List<BucketList> BucketLists { get; set; }

        public int GetYear(DateTime releaseDate)
        {
            return releaseDate.Year;
        }
    }
}
