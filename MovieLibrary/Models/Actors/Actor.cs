using MovieLibrary.Models.Relations;

namespace MovieLibrary.Models.Actors
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public List<Actor_Movie> ActorsMovies { get; set; }
        public List<Actor_ActorAward> Actor_ActorAwards { get; set; }

    }
}
