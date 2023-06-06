using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieLibrary.Models.Movies
{
    public class MovieComment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedTime { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}