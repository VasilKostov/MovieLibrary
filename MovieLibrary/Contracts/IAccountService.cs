using MovieLibrary.Models;
using MovieLibrary.Models.Movies;

namespace MovieLibrary.Contracts
{
    public interface IAccountService
    {
        Task<bool> EmailExists(string email);

        /// <summary>
        /// Gets the account posted comments by userId
        /// </summary>
        Task<List<MovieComment>?> GetComments(string userId);

        /// <summary>
        /// Gets all created (accepted) movies by the account using userId
        /// </summary>
        Task<List<Movie>?> GetMovies(string userId);

        /// <summary>
        /// Get user's profile information
        /// </summary>
        /// <returns>Tuple of Lists that contain comments and created movies</returns>
        Task<(List<MovieComment>? comments, List<Movie>? createdMovies)> GetProfileInfo(string userId);
        Task<List<AppUser>> GetUsers();

        /// <summary>
        /// Gets all users and sets their roles
        /// </summary>
        /// <returns>Returns a list of Appusers order first by role then by Id</returns>
        Task<List<AppUser>> GetUsersList();
        Task<List<AppUser>> SetUserRoles(List<AppUser> users);
        Task<bool> UsernameExists(string userName);
    }
}
