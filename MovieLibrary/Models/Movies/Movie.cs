using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieLibrary.Models.Relations;

namespace MovieLibrary.Models.Movies
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public DateTime ReleaseDate { get; set; }
        //One movie multiple comments e.g
        //public guid userid
        public List<MovieComment> CommentsOnMovies { get; set; }
        //make the same as movieActors
        //public ICollection<MovieAward> MovieAwards { get; set; }
        public int MinimumAge { get; set; }
        public double Rating { get; set; }
        public int UsersRated { get; set; }
        public string Description { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public List<Movie_MovieAward> Movie_MovieAwards { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public MovieCategory Category { get; set; }
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
        //public virtual AppUser AppUser { get; set; }
        //public virtual ICollection<MovieComment> Comments { get; set; }
    }
}
