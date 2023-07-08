using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task DeleteUser(AppUser user)
        {
            db.AppUser.Remove(user);
            await db.SaveChangesAsync();
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

        public async Task<string?> GetCurrentUserRole(IdentityUserRole<string> userRole)
        {
            return await db.Roles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefaultAsync();
        }

        public async Task<string?> GetCurrentUserRole(AppUser user)
        {
            var role = await db.Roles.FirstOrDefaultAsync(u => u.Id == user.RoleId);

            return role?.Name;
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
            return (await GetComments(userId), await GetMovies(userId));
        }

        public async Task<List<AppUser>> GetSearchedUsers(string? data)
        {
            if (string.IsNullOrEmpty(data))
                return await GetUsersList();

            var users = await( from  user in db.Users
                               where user.Email.Contains(data) || user.UserName.Contains(data)
                               select user)
                               .ToListAsync();

            users = await SetUserRoles(users);

            return users.OrderByDescending(u => u.Role).ThenBy(u => u.Email).ToList();
        }

        public async Task<IdentityUserRole<string>?> GetUserRole(string userId)
        {
            return await db.UserRoles.FirstOrDefaultAsync(u => u.UserId == userId);
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

        public async Task<AppUser> SetUserRole(AppUser user)
        {
            var userRole = await db.UserRoles.ToListAsync();
            var roles = await db.Roles.ToListAsync();
            var role = userRole.FirstOrDefault(u => u.UserId == user.Id);

            if (role is not null)
                user.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId)!.Id;

            user.RoleList = db.Roles.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id
            });

            return user;
        }

        /// <summary>
        /// Sets all user's role
        /// </summary>
        /// <returns>Returns them in certain order</returns>
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

            return users.OrderByDescending(u => u.Role).ThenBy(u => u.Id).ToList();
        }

        public async Task<bool> UsernameExists(string userName)
        {
            return await db.AppUser.AnyAsync(x => x.UserName == userName);
        }
    }
}
