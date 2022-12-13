using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models.Movies
{
    public class MovieComment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        public AppUser AppUser { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public string Text { get; set; }
    }
}