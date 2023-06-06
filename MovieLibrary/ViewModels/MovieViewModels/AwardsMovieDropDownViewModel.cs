using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieLibrary.ViewModels.MovieViewModels
{
    public class AwardsMovieDropDownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> AllAwards { get; set; }
    }
}
