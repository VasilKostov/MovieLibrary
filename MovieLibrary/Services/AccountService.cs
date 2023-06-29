using Microsoft.EntityFrameworkCore;
using MovieLibrary.Contracts;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Movies;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext db;

        public AccountService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await db.AppUser.AnyAsync(x => x.Email == email);
        }

        /// <summary>
        /// Gets the account posted comments by userId
        /// </summary>
        public async Task<List<MovieComment>?> GetComments(string userId)
        {
            return await db.MovieComments.Where(c => c.AppUserId == userId).ToListAsync();
        }

        /// <summary>
        /// Gets all created (accepted) movies by the account using userId
        /// </summary>
        public async Task<List<Movie>?> GetMovies(string userId)
        {
           return await db.Movies.Where(m => m.AppUserId == userId && m.Accepted == true).ToListAsync();
        }

        /// <summary>
        /// Get user's profile information
        /// </summary>
        /// <returns>Tuple of Lists that contain comments and created movies</returns>
        public async Task<(List<MovieComment>? comments, List<Movie>? createdMovies)> GetProfileInfo(string userId)
        {
            return ( await GetComments(userId),  await GetMovies(userId));
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await db.AppUser.ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersList()
        {
            var users = await GetUsers();
            return await SetUserRoles(users);
        }

        public async Task<List<AppUser>> SetUserRoles(List<AppUser> users)
        {
            var userRoles = await db.UserRoles.ToListAsync();
            var roles = await db.Roles.ToListAsync();

            foreach (var user in users)
            {
                var role = userRoles.FirstOrDefault(u => u.UserId == user.Id);

                if (role is null)
                    user.Role = "None";
                else
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId)!.Name;
            }

            return users;
        }

        public async Task<bool> UsernameExists(string userName)
        {
            return await db.AppUser.AnyAsync(x => x.UserName == userName);
        }
    }
}
