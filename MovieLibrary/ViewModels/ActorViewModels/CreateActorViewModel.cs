using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Models.Actors;

namespace MovieLibrary.ViewModels.ActorViewModels
{
    public class CreateActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ActorGender Gender { get; set; }

        public IEnumerable<SelectListItem> AllActorAwards { get; set; }
        public int[] SelectedActorAwardsIds { get; set; }
    }
}
