﻿using MovieLibrary.Models.Relations;

namespace MovieLibrary.Models.Movies
{
    public class MovieAward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie_MovieAward> Movie_MovieAwards { get; set; }
    }
}