using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieLibrary.Models.Actors
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName+" "+LastName;
        [EnumDataType(typeof(ActorGender))]
        public ActorGender Gender { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public List<Actor_ActorAward> Actor_ActorAwards { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
