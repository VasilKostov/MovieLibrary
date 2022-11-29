using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string? RoleId { get; set; }
        [NotMapped]
        public string? Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
        //public string Country { get; set; }
        //public string FavouriteGenre { get; set; }

        //Is not get; set; change it!!
        //public List<string> Comments { get; set; }

        //public List<Movies> PostedMovies { get; set; }
    }
}
