using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Contracts;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext db;

        public MovieService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<List<Actor>> GetActors()
        {
            return await db.Actors.ToListAsync();
        }

        /// <summary>
        /// Gets all movies for a certain user based on his age and whether the movie is accepted or not
        /// </summary>
        public async Task<List<Movie>> GetAllMovies(AppUser user)
        {
            return await db.Movies
                .Where(m => m.MinimumAge <= user.Age && m.Accepted)
                .ToListAsync();
        }

        public async Task<List<MovieComment>?> GetCommentByMovieId(int movieId)
        {
            return await db.MovieComments
                .Where(c => c.MovieId == movieId)
                .ToListAsync();
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await db.Movies
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<AppUser?> GetUserById(string userId)
        {
            return await db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<MovieAward>> GetAwards()
        {
            return await db.MovieAwards.ToListAsync();
        }

        public async Task<List<Producer>> GetProducers()
        {
            return await db.Producers.ToListAsync();
        }

        public async Task CreateMovie(Movie movie)
        {
            if (!await MovieAlereadyExists(movie))
            {
                await db.AddAsync(movie);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> MovieAlereadyExists(Movie movie)
        {
            return await db.Movies
                .AnyAsync(m => m.ReleaseDate == movie.ReleaseDate &&
                    m.Title == movie.Title &&
                    m.ProducerId == movie.ProducerId);
        }

        public async Task AddMovieAwards(int[]? awardsIds, int movieId)
        {
            if (awardsIds is not null || awardsIds?.Length > 0)
            {
                foreach (var id in awardsIds)
                {
                    var newMovieWithAwards = new Movie_MovieAward()
                    {
                        MovieId = movieId,
                        MovieAwardId = id
                    };

                    await db.Movie_MovieAwards.AddAsync(newMovieWithAwards);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task AddActors(int[] actorsIds, int movieId)
        {
            foreach (var id in actorsIds)
            {
                var newMovieWithActor = new Actor_Movie()
                {
                    MovieId = movieId,
                    ActorId = id
                };

                await db.Actors_Movies.AddAsync(newMovieWithActor);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteMovie(Movie? movie)
        {
            if (movie is not null)
            {
                if (await MovieAlereadyExists(movie))
                {
                    db.Remove(movie);
                    await db.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Gets movies for MovieList ordered by certain way and are also accepted by Admin/Manager
        /// </summary>
        public async Task<List<Movie>?> GetMovies()
        {
            return await db.Movies
                .Where(m => m.Accepted)
                .OrderByDescending(u => u.AppUserId)
                .ThenBy(u => u.Category)
                .ToListAsync();
        }

        /// <summary>
        /// By given movies the function sets the user's role, who created the exact movie.
        /// </summary>
        /// <returns>Returns tuple of creator's role and the movie he created for view purposes</returns>
        public async Task<List<(string, Movie)>?> SetMovieAndRole(List<Movie>? movies)
        {
            if (movies is null || movies.Count <= 0)
                return null;

            var model = new List<(string, Movie)>();

            foreach (var movie in movies)
                model.Add((await GetCreatorsRole(movie.AppUserId), movie));

            return model;
        }

        public async Task<string> GetCreatorsRole(string? userId)
        {
            if (string.IsNullOrEmpty(userId))
                return "Problem with role";

            var userRole = await db.UserRoles.Where(u => u.UserId == userId).FirstAsync();
            var role = await db.Roles.Where(r => r.Id == userRole.RoleId).FirstAsync();

            return role.Name;
        }

        public async Task<MovieComment?> GetComment(int commentId)
        {
            return await db.MovieComments.FirstOrDefaultAsync(u => u.Id == commentId);
        }

        public async Task DeleteComment(MovieComment? comment)
        {
            if (comment is not null)
            {
                db.Remove(comment);
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets the actors which are playing a certain movie
        /// </summary>
        public async Task<List<Actor>> GetActors(int movieId)
        {
            var actorMovies = await db.Actors_Movies.Where(am => movieId == am.MovieId).ToListAsync();
            var actors = new List<Actor>();

            foreach (var am in actorMovies)
                actors.Add(await GetActor(am.ActorId));

            return actors;
        }

        public async Task<Actor> GetActor(int actorId)
        {
            return await db.Actors.Where(a => a.Id == actorId).FirstAsync();
        }

        public async Task<Producer> GetProducer(int producerId)
        {
            return await db.Producers.Where(p => p.Id == producerId).FirstAsync();
        }

        public async Task<List<MovieAward>?> GetAwards(int movieId)
        {
            var movieAwards = await db.Movie_MovieAwards.Where(ma => movieId == ma.MovieId).ToListAsync();
            var awards = new List<MovieAward>();

            foreach (var ma in movieAwards)
                awards.Add(await GetMovieAward(ma.MovieAwardId));

            return awards;
        }

        public async Task<MovieAward> GetMovieAward(int awardId)
        {
            return await db.MovieAwards.Where(a => a.Id == awardId).FirstAsync();
        }

        public async Task<List<Movie_MovieAward>> GetMovie_MovieAwards(int movieId)
        {
            return await db.Movie_MovieAwards.Where(mma => mma.MovieId == movieId).ToListAsync();
        }

        public async Task<List<Actor_Movie>> GetMovieActors(int movieId)
        {
            return await db.Actors_Movies.Where(am => am.MovieId == movieId).ToListAsync();
        }

        public async Task RemoveMovieAwards(int movieId)
        {
            var movieAwards = await GetMovie_MovieAwards(movieId);

            db.RemoveRange(movieAwards);
        }

        public async Task RemoveMovieActors(int movieId)
        {
            var movieActors = await GetMovieActors(movieId);

            db.RemoveRange(movieActors);
        }

        public async Task<List<Movie>?> GetMovies(bool accepted)
        {
            return await db.Movies.Where(m => m.Accepted == accepted).ToListAsync();
        }

        /// <summary>
        /// Updates the status of acceptance of a certain movie
        /// </summary>
        public async Task UpdateMovie(int movieId)
        {
            var movie = await GetMovieById(movieId);

            if (movie is not null)
                movie.Accepted = true;

            await db.SaveChangesAsync();
        }

        public async Task<List<Favourite>?> GetFavorites(string userId)
        {
            return await db.Favourites.Where(m => m.AppUserId == userId).ToListAsync();
        }

        public async Task<List<Movie>?> GetUserFavorites(string userId)
        {
            var favMovies = await GetFavorites(userId);

            if (favMovies is null || favMovies.Count < 0)
                return new List<Movie>();

            var movies = new List<Movie>();
            var allMovies = await GetMovies(true);

            if (allMovies is null)
                return movies;

            foreach (var movie in favMovies)
                movies.Add(allMovies.First(m => m.Id == movie.MovieId));

            return movies;
        }

        public async Task<bool> IsInFavourites(Favourite favourite)
        {
            return await db.Favourites.ContainsAsync(favourite);
        }

        public async Task AddFavourites(Favourite favourite)
        {
            if (!await IsInFavourites(favourite))
            {
                await db.Favourites.AddAsync(favourite);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Movie>?> GetBucketMovies(string userId)
        {
            var bucketList = await GetBucketList(userId);
            var AllMovies = await GetMovies();
            var movies = new List<Movie>();

            if (bucketList is null)
                return movies;

            foreach (var movie in bucketList)
                movies.Add(AllMovies!.First(m => m.Id == movie.MovieId));

            return movies;
        }

        public async Task<List<BucketList>?> GetBucketList(string userId)
        {
            return await db.BucketLists.Where(m => m.AppUserId == userId).ToListAsync();
        }

        public async Task<bool> IsInBucketList(BucketList bucket)
        {
            return await db.BucketLists.ContainsAsync(bucket);
        }

        public async Task AddBucket(BucketList bucket)
        {
            await db.BucketLists.AddAsync(bucket);
            await db.SaveChangesAsync();
        }

        public async Task RemoveBucketListMovie(int movieId, string userId)
        {
            var movieToRemove = await GetBucketList(movieId, userId);

            if (movieToRemove is null) return;

            db.BucketLists.Remove(movieToRemove);
            await db.SaveChangesAsync();
        }

        public async Task<BucketList?> GetBucketList(int movieId, string userId)
        {
            return await db.BucketLists.Where(b => b.MovieId == movieId && b.AppUserId == userId).FirstOrDefaultAsync();
        }

        public async Task AddComment(MovieComment comment)
        {
            await db.MovieComments.AddAsync(comment);
            await db.SaveChangesAsync();
        }

        public async Task RemoveFavourite(int movieId, string userId)
        {
            var movieToRemove = await GetFavourite(movieId, userId);

            if (movieToRemove is null) return;

            db.Favourites.Remove(movieToRemove);
            await db.SaveChangesAsync();
        }

        public async Task<Favourite?> GetFavourite(int movieId, string userId)
        {
            return await db.Favourites.Where(f => f.MovieId == movieId && f.AppUserId == userId).FirstOrDefaultAsync();
        }
    }
}
