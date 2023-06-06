using MovieLibrary.Models.Movies;

namespace MovieLibrary.ViewModels
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Budget { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MinimumAge { get; set; }
        public double Rating { get; set; }
        public int UsersRated { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PosterSource { get; set; } = string.Empty;
        public bool Accepted { get; set; }
        public string YoutubeTrailerId { get; set; } = string.Empty;

        public string? Comment { get; set; }
        public List<MovieComment>? Comments { get; set; }
    }
}
