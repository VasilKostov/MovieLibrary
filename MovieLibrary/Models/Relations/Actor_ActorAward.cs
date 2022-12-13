using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary.Models.Relations
{
    public class Actor_ActorAward
    {
        public int ActorAwardId { get; set; }
        [ForeignKey("ActorAwardId")]
        public ActorAward ActorAward { get; set; }
        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
    }
}
