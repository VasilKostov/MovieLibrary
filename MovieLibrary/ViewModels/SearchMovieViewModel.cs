namespace MovieLibrary.ViewModels
{
    public class SearchMovieViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set;}
        public string PosterUrl { get; set; } = null!;
    }
}
