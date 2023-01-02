using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models.Relations
{
    public class Actor_ActorAward
    {
        public int ActorAwardId { get; set; }
        public ActorAward ActorAward { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
