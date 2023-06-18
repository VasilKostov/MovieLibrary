﻿using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Contracts
{
    public interface IMovieService
    {
        Task<AppUser?> GetUserById(string userId);
        Task<List<Movie>> GetAllMovies(AppUser user);
        Task<Movie?> GetMovieById(int id);
        Task<List<MovieComment>?> GetCommentByMovieId(int movieId);
        Task<List<MovieAward>> GetAwards();
        Task<List<Producer>> GetProducers();
        Task<List<Actor>> GetActors();
        Task CreateMovie(Movie movie);
        Task<bool> MovieAlereadyExists(Movie movie);
        Task AddMovieAwards(int[] awardsIds, int movieId);
        Task AddActors(int[] actorsIds, int movieId);
        Task DeleteMovie(Movie? movie);
        Task<List<Movie>?> GetMovies();
        Task<List<(string, Movie)>?> SetMovieAndRole(List<Movie>? movies);
        Task<string> GetCreatorsRole(string? userId);
    }
}
