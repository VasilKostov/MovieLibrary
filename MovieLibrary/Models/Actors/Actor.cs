using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.Actors
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EnumDataType(typeof(ActorGender))]
        public ActorGender Gender { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public List<Actor_ActorAward> Actor_ActorAwards { get; set; }

    }
}
