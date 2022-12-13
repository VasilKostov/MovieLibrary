using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models.Relations
{
    public class Movie_MovieAward
    {
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int MovieAwardId { get; set; }
        [ForeignKey("MovieAwardId")]
        public MovieAward MovieAward { get; set; }
    }
}
