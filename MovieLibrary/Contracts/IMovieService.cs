using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Contracts
{
    public interface IMovieService
    {
        Task<AppUser?> GetUserById(string userId);

        /// <summary>
        /// Gets all movies for a certain user based on his age and whether the movie is accepted or not
        /// </summary>
        Task<List<Movie>> GetAllMovies(AppUser user);
        Task<Movie?> GetMovieById(int id);
        Task<List<MovieComment>?> GetCommentByMovieId(int movieId);
        Task<List<MovieAward>> GetAwards();
        Task<List<Producer>> GetProducers();
        Task<List<Actor>> GetActors();
        Task<Actor> GetActor(int actorId);

        /// <summary>
        /// Gets the actors which are playing a certain movie
        /// </summary>
        Task<List<Actor>> GetActors(int movieId);
        Task CreateMovie(Movie movie);
        Task<bool> MovieAlereadyExists(Movie movie);
        Task AddMovieAwards(int[]? awardsIds, int movieId);
        Task AddActors(int[] actorsIds, int movieId);
        Task DeleteMovie(Movie? movie);

        /// <summary>
        /// Gets movies for MovieList ordered by certain way and are also accepted by Admin/Manager
        /// </summary>
        Task<List<Movie>?> GetMovies();
        Task<List<Movie>?> GetMovies(bool accepted);

        /// <summary>
        /// By given movies the function sets the user's role, who created the exact movie.
        /// </summary>
        /// <returns>Returns tuple of creator's role and the movie he created for view purposes</returns>
        Task<List<(string, Movie)>?> SetMovieAndRole(List<Movie>? movies);
        Task<string> GetCreatorsRole(string? userId);
        Task<MovieComment?> GetComment(int commentId);
        Task DeleteComment(MovieComment? comment);
        Task<Producer> GetProducer(int producerId);
        Task<List<MovieAward>?> GetAwards(int movieId);
        Task<MovieAward> GetMovieAward(int awardId);
        Task RemoveMovieAwards(int movieId);
        Task<List<Movie_MovieAward>> GetMovie_MovieAwards(int movieId);
        Task RemoveMovieActors(int movieId);
        Task<List<Actor_Movie>> GetMovieActors(int movieId);

        /// <summary>
        /// Updates the status of acceptance of a certain movie
        /// </summary>
        Task UpdateMovie(int movieId);
        Task<List<Favourite>?> GetFavorites(string userId);
        Task<List<Movie>?> GetUserFavorites(string userId);
        Task<bool> IsInFavourites(Favourite favourite);
        Task AddFavourites(Favourite favourite);
        Task<List<Movie>?> GetBucketMovies(string userId);
        Task<List<BucketList>?> GetBucketList(string userId);
        Task<bool> IsInBucketList(BucketList bucket);
        Task AddBucket(BucketList bucket);
        Task RemoveBucketListMovie(int movieId, string userId);
        Task<BucketList?> GetBucketList(int movieId, string userId);
        Task AddComment(MovieComment comment);
        Task RemoveFavourite(int movieId, string userId);
        Task<Favourite?> GetFavourite(int movieId, string userId);
        Task<List<ActorAward>> GetActorAwards();
        Task CreateActor(Actor actor);
        Task AddActorAwards(int[]? selectedActorAwardsIds, Actor? actor);
        Task RateMovie(int? movieId, int? rate);
    }
}
