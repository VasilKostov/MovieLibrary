using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieLibrary.ViewModels.ActorViewModels
{
    public class AwardsActorDropDownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> AllAwards { get; set; }
    }
}
