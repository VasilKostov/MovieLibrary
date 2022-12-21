using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models.Relations
{
    public class Movie_MovieAward
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int MovieAwardId { get; set; }
        public MovieAward MovieAward { get; set; }
    }
}
