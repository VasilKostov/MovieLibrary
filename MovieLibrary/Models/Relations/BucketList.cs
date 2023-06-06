using MovieLibrary.Models.Movies;

namespace MovieLibrary.Models.Relations
{
    public class BucketList
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
