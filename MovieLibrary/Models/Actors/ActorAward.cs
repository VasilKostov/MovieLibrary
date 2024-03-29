﻿using MovieLibrary.Models.Relations;

namespace MovieLibrary.Models.Actors
{
    public class ActorAward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Actor_ActorAward>? Actor_ActorAwards { get; set; }
    }
}