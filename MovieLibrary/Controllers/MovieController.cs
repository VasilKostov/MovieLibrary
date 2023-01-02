using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.ViewModels.MovieViewModels.CreateMovie;
using NuGet.Protocol;
using System.Diagnostics.Metrics;
using System.Net;

namespace MovieLibrary.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult AllMoviesDetails()
        {
            var movies = _db.Movies;
            return View(movies.ToList());
        }

        [HttpGet]
        public IActionResult MovieDetails(int? movieId)
        {
            if (movieId == null)
            {
                throw new Exception("No movie could be found!");
            }
            Movie movie = _db.Movies.FirstOrDefault(m=>m.Id==movieId);
            return View(movie);
        }
        public IActionResult Index()
        {
            var movieList = _db.Movies.ToList();

            return View(movieList.OrderByDescending(u => u.AppUserId).ThenBy(u => u.Category).ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMovieViewModel();

            IEnumerable<MovieAward> movieAwards = _db.MovieAwards;
            IEnumerable<Producer> movieProducers = _db.Producers;
            IEnumerable<Actor> movieActors = _db.Actors;
            model.AllMovieAwards = new SelectList(movieAwards, "Id", "Name");
            model.AllProducers = new SelectList(movieProducers, "Id", "Name");
            model.AllMovieActors = new SelectList(movieActors, "Id", "FullName");
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateMovieViewModel model)
        {
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user.Id == null)
            {
                throw new Exception("No authenticated user could be found!");
            }
            Movie newMovie = new Movie()
            {
                Title = model.Title,
                Budget = model.Budget,
                ReleaseDate = model.ReleaseDate,
                MinimumAge = model.MinimumAge,
                Description = model.Description,
                Category = model.Category,
                AppUserId = user.Id,
                ProducerId = model.ProducerId,
                AppUserEmail = user.Email,
            };
            _db.Movies.Add(newMovie);
            _db.SaveChanges();
            //Create method for the connection in movie.cs
            foreach (var awardId in model.SelectedMovieAwardsIds)
            {
                Movie_MovieAward newMovieWithAwards = new Movie_MovieAward()
                {
                    MovieId = newMovie.Id,
                    MovieAwardId = awardId
                };
                _db.Movie_MovieAwards.Add(newMovieWithAwards);
                _db.SaveChanges();
            }
            foreach (var actorId in model.SelectedMovieActorsIds)
            {
                Actor_Movie newMovieWithActor = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                _db.Actors_Movies.Add(newMovieWithActor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Create));
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public IActionResult Update(int movieId)
        {
            var movie = _db.Movies.FirstOrDefault(u => u.Id == movieId);
            IEnumerable<MovieAward> movieAwards = _db.MovieAwards;
            IEnumerable<Producer> movieProducers = _db.Producers;
            IEnumerable<Actor> movieActors = _db.Actors;
            if (movie == null)
            {
                return NotFound();
            }
            movie.AllMovieAwards = new SelectList(movieAwards, "Id", "Name");
            movie.AllProducers = new SelectList(movieProducers, "Id", "Name");
            movie.AllMovieActors = new SelectList(movieActors, "Id", "FullName");
            //movie.SelectedProducerId = movie.ProducerId;
            //List<int> selectedActorsIds = new List<int>();
            //IEnumerable<Actor_Movie> allActors = _db.Actors_Movies;
            //foreach (var actor in allActors.Where(a => a.MovieId == movie.Id))
            //{
            //    selectedActorsIds.Add(actor.ActorId);
            //}
            //movie.SelectedMovieActorsIds = selectedActorsIds.ToArray();

            //List<int> selectedAwardsIds = new List<int>();
            //IEnumerable<Movie_MovieAward> allAwards = _db.Movie_MovieAwards;
            //foreach (var award in allAwards.Where(a => a.MovieId == movie.Id))
            //{
            //    selectedAwardsIds.Add(award.MovieAwardId);
            //}
            //movie.SelectedMovieAwardsIds = selectedAwardsIds.ToArray();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Movie movie)
        {
            var movieToUpdate = _db.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (movieToUpdate == null)
            {
                throw new Exception("No such movie could be found!");
            }
            movieToUpdate.Title = movie.Title;
            movieToUpdate.Budget = movie.Budget;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.MinimumAge = movie.MinimumAge;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.Category = movie.Category;
            _db.SaveChanges();
            IEnumerable<Movie_MovieAward> movieAwards = _db.Movie_MovieAwards;
            IEnumerable<Actor_Movie> movieActors = _db.Actors_Movies;
            _db.RemoveRange(movieAwards.Where(a => a.MovieId == movie.Id));
            _db.RemoveRange(movieActors.Where(a => a.MovieId == movie.Id));

            foreach (var awardId in movie.SelectedMovieAwardsIds)
            {
                Movie_MovieAward newMovieWithAwards = new Movie_MovieAward()
                {
                    MovieId = movie.Id,
                    MovieAwardId = awardId
                };
                _db.Movie_MovieAwards.Add(newMovieWithAwards);
                _db.SaveChanges();
            }
            foreach (var actorId in movie.SelectedMovieActorsIds)
            {
                Actor_Movie newMovieWithActor = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                _db.Actors_Movies.Add(newMovieWithActor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int movieId)
        {
            var movie = _db.Movies.FirstOrDefault(u => u.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
