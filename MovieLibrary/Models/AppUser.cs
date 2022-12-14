using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations;
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
        [NotMapped]
        public ICollection<MovieComment>? MovieComments { get; set; }
        [NotMapped]
        public ICollection<Movie>? Movies { get; set; }
        [NotMapped]
        public ICollection<Actor>? Actors { get; set; }

        //public string Country { get; set; }
        //public string FavouriteGenre { get; set; }

        //Is not get; set; change it!!


        //public List<Movies> PostedMovies { get; set; }
    }
}
