using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.ViewModels;
using MovieLibrary.ViewModels.MovieViewModels;
using NuGet.Configuration;
using NuGet.Protocol;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace MovieLibrary.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MovieController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Movies
        [HttpGet]
        public IActionResult AllMoviesDetails()
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var movies = _db.Movies.Where(m => m.MinimumAge <= user.Age && m.Accepted == true).ToList();

            return View(movies);
        }
        #endregion

        #region Movie
        [HttpGet]
        public IActionResult MovieDetails(int? movieId)
        {
            if (movieId is null)
                return View("Error", "Nullable exception in AppUsers");

            var movie = _db.Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie is null)
                return View("Error", "Nullable exception in Movies");

            var comments = _db.MovieComments.Where(c => c.MovieId == movie.Id).ToList();

            var model = new MovieDetailsViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Budget = movie.Budget,
                PosterSource = movie.PosterSource!,
                UsersRated = movie.UsersRated,
                Rating = movie.Rating,
                Comments = comments,
                Accepted = movie.Accepted,
                MinimumAge = movie.MinimumAge,
                YoutubeTrailerId = movie.TrailerUrl!
            };

            return View(model);
        }
        #endregion

        #region Waitlist
        public IActionResult Index()
        {
            var movieList = _db.Movies.Where(m => m.Accepted == true).OrderByDescending(u => u.AppUserId).ThenBy(u => u.Category).ToList();
            var movieAndRole = new List<(string, Movie)>();

            foreach (var movie in movieList)
            {
                var roleId = _db.UserRoles.Where(r => r.UserId == movie.AppUserId).First().RoleId;
                var role = _db.Roles.Where(r => r.Id == roleId).First().Name;
                movieAndRole.Add((role!, movie));
            }

            return View(movieAndRole);
        }
        #endregion

        #region CreateMovie
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMovieViewModel();

            List<MovieAward> movieAwards = _db.MovieAwards.ToList();
            List<Producer> movieProducers = _db.Producers.ToList();
            List<Actor> movieActors = _db.Actors.ToList();
            model.AllMovieAwards = new SelectList(movieAwards, "Id", "Name").ToList();
            model.AllProducers = new SelectList(movieProducers, "Id", "Name").ToList();
            model.AllMovieActors = new SelectList(movieActors, "Id", "FullName").ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel model)
        {
            AppUser? user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception");

            var newMovie = new Movie()
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
                PosterFile = model.Poster,
                Accepted = false,
                TrailerUrl = GetIdFromYoutubeUrl(model.YoutubeUrl)
            };

            if (model.Poster is null)
            {
                ModelState.AddModelError(string.Empty, "Please upload a file.");
                throw new Exception("Please upload a file.");
            }
            else if (model.Poster.Length > 0 && model.Poster is not null)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/posters", model.Poster.FileName);

                using (var memoryStream = new MemoryStream())
                {
                    await model.Poster.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 2097152)// Upload the file if less than 2 MB
                        newMovie.PosterSource = ChangePicturePath(path);
                    else
                        ModelState.AddModelError(string.Empty, "The file is too large. It must be under 2 MB");
                }

                using FileStream stream = new FileStream(path, FileMode.Create);
                await model.Poster.CopyToAsync(stream);
                stream.Close();
            }

            _db.Movies.Add(newMovie);
            _db.SaveChanges();

            foreach (var awardId in model.SelectedMovieAwardsIds)
            {
                var newMovieWithAwards = new Movie_MovieAward()
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
        #endregion

        #region UpdateMovie
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public IActionResult Update(int movieId)
        {
            var movie = _db.Movies.FirstOrDefault(u => u.Id == movieId);
            var allmovieAwards = _db.MovieAwards.ToList();
            var allmovieProducers = _db.Producers.ToList();
            var allmovieActors = _db.Actors.ToList();

            if (movie is null)
                return View("Error", "Nullable exception in Movies");

            //Getting the ids of actors and awards
            var selectedActorsIds = new List<int>();
            var allActors = _db.Actors_Movies.ToList();

            foreach (var actor in allActors.Where(a => a.MovieId == movie.Id))
                selectedActorsIds.Add(actor.ActorId);

            var selectedAwardsIds = new List<int>();
            var allAwards = _db.Movie_MovieAwards.ToList();

            foreach (var award in allAwards.Where(a => a.MovieId == movie.Id))
                selectedAwardsIds.Add(award.MovieAwardId);

            //Getting the actual obj
            var movieProducer = _db.Producers.First(p => p.Id == movie.ProducerId);

            var movieActors = new List<Actor>();

            foreach (var actorId in selectedActorsIds)
                movieActors.Add(allmovieActors.First(i => i.Id == actorId));

            var movieAwards = new List<MovieAward>();

            foreach (var awardId in selectedAwardsIds)
                movieAwards.Add(allmovieAwards.First(i => i.Id == awardId));

            var viewModel = new UpdateMovieViewModel()
            {
                Movie = movie,
                Producer = movieProducer,
                Awards = movieAwards,
                Actors = movieActors,
                AllMovieAwards = new SelectList(allmovieAwards, "Id", "Name").ToList(),
                AllMovieActors = new SelectList(allmovieActors, "Id", "FullName").ToList(),
                AllProducers = new SelectList(allmovieProducers, "Id", "Name").ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateMovieViewModel model)
        {
            var movie = model.Movie;
            var movieToUpdate = _db.Movies.FirstOrDefault(m => m.Id == movie.Id);

            if (movieToUpdate is null || movie is null)
                return View("Error", "Nullable exception in Movies");

            if (movie.PosterFile is null)
                movieToUpdate.PosterSource = movieToUpdate.PosterSource;
            else if (movie.PosterFile.Length > 0 && movie.PosterFile != null)
            {
                if (movieToUpdate.PosterSource is not null)
                {
                    var deletePath = "wwwroot" + movieToUpdate.PosterSource.Substring(1);
                    if (System.IO.File.Exists(deletePath))
                        System.IO.File.Delete(deletePath);
                }
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/posters", movie.PosterFile.FileName);

                using (var memoryStream = new MemoryStream())
                {
                    await movie.PosterFile.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 2097152)// Upload the file if less than 2 MB  
                        movieToUpdate.PosterSource = ChangePicturePath(path);
                    else
                        ModelState.AddModelError(string.Empty, "The file is too large. It must be under 2 MB");
                }
                using FileStream stream = new FileStream(path, FileMode.Create);
                await movie.PosterFile.CopyToAsync(stream);
                stream.Close();
            }

            movieToUpdate.Title = movie.Title;
            movieToUpdate.Budget = movie.Budget;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.MinimumAge = movie.MinimumAge;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.Category = movie.Category;

            //If the array of Ids is empty that means that the user wants to leave the movie with the same Actors/Awards/Producer
            if (model.SelectedMovieProducerId is not null && model.SelectedMovieProducerId is not 0)
                movieToUpdate.ProducerId = (int)model.SelectedMovieProducerId!;

            _db.SaveChanges();

            if (model.SelectedMovieAwardsIds is not null)
            {
                var movieAwards = _db.Movie_MovieAwards.ToList();

                _db.RemoveRange(movieAwards.Where(a => a.MovieId == movie.Id));

                foreach (var awardId in model.SelectedMovieAwardsIds)
                {
                    var newMovieWithAwards = new Movie_MovieAward()
                    {
                        MovieId = movie.Id,
                        MovieAwardId = awardId
                    };

                    _db.Movie_MovieAwards.Add(newMovieWithAwards);
                    _db.SaveChanges();
                }
            }

            if (model.SelectedMovieActorsIds is not null)
            {
                var movieActors = _db.Actors_Movies.ToList();

                _db.RemoveRange(movieActors.Where(a => a.MovieId == movie.Id));

                foreach (var actorId in model.SelectedMovieActorsIds)
                {
                    var newMovieWithActor = new Actor_Movie()
                    {
                        MovieId = movie.Id,
                        ActorId = actorId
                    };

                    _db.Actors_Movies.Add(newMovieWithActor);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region DeleteMovie
        [HttpPost]
        public IActionResult Delete(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return View("Error", "Nullable exception in Movies");

            var movie = _db.Movies.FirstOrDefault(u => u.Id == movieId);

            if (movie is null)
                return View("Error", "Nullable exception in Movies");

            //Delete poster from files
            if (movie.PosterSource is not null)
            {
                var deletePath = "wwwroot" + movie.PosterSource.Substring(1);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
            }

            _db.Movies.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region DeleteComment
        [HttpPost]
        public IActionResult DeleteComment(int? commentId)
        {
            if (commentId is null || commentId is 0)
                return View("Error", "Nullable exception in Comments");

            var comment = _db.MovieComments.FirstOrDefault(u => u.Id == commentId);
            if (comment is null)
                return View("Error", "Nullable exception in Comments");

            int movieId = comment.MovieId;

            _db.MovieComments.Remove(comment);
            _db.SaveChanges();

            return RedirectToAction("MovieDetails", new { movieId = comment.MovieId });
        }
        #endregion

        #region Accept
        [HttpGet]
        public IActionResult Accept()
        {
            AppUser? user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var movies = _db.Movies.Where(m => m.Accepted == false).ToList();

            return View(movies);
        }

        [HttpPost]
        public IActionResult Accept(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return View("Error", "Nullable exception in Movies");

            Movie? movie = _db.Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie is null)
                return View("Error", "Nullable exception");

            movie.Accepted = true;

            _db.SaveChanges();

            return RedirectToAction(nameof(Accept));
        }
        #endregion

        #region Favourite
        [HttpGet]
        public IActionResult Favourite()
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var favUserMovies = _db.Favourites.Where(m => m.AppUserId == user.Id).ToList();
            var movies = new List<Movie>();
            var AllMovies = _db.Movies.ToList();

            if (AllMovies is null || favUserMovies is null)
                return View(movies);

            foreach (var movie in favUserMovies)
            {
                movies.Add(AllMovies.First(m => m.Id == movie.MovieId));
            }

            return View(movies);
        }

        [HttpPost]
        public IActionResult Favourite(int movieId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var favouriteMovieToAdd = new Favourite()
            {
                MovieId = movieId,
                AppUserId = user.Id
            };

            if (_db.Favourites.Contains(favouriteMovieToAdd))
                return RedirectToAction(nameof(AllMoviesDetails));

            _db.Favourites.Add(favouriteMovieToAdd);
            _db.SaveChanges();

            return RedirectToAction(nameof(AllMoviesDetails));
        }
        #endregion

        #region Bucketlist
        [HttpGet]
        public IActionResult BucketList()
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var bucketListUserMovies = _db.BucketLists.Where(m => m.AppUserId == user.Id).ToList();
            var movies = new List<Movie>();
            var AllMovies = _db.Movies.ToList();

            if (AllMovies is null || bucketListUserMovies is null)
                return View(movies);

            foreach (var movie in bucketListUserMovies)
                movies.Add(AllMovies.First(m => m.Id == movie.MovieId));

            return View(movies);
        }

        [HttpPost]
        public IActionResult BucketList(int movieId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var bucketListToAdd = new BucketList()
            {
                MovieId = movieId,
                AppUserId = user.Id
            };

            if (_db.BucketLists.Contains(bucketListToAdd))
                return RedirectToAction(nameof(AllMoviesDetails));

            _db.BucketLists.Add(bucketListToAdd);
            _db.SaveChanges();

            return RedirectToAction(nameof(AllMoviesDetails));
        }
        #endregion

        [HttpGet]
        public IActionResult ConvertBucketListToPDf()
        {
            string html = GetBucketListHtml();

            string combinedContent = $"<html><head><style></style></head><body>{html}</body></html>";

            var renderer = new HtmlToPdf();
            var pdf = renderer.RenderHtmlAsPdf(combinedContent);

            return File(pdf.BinaryDataIncremental, "application/pdf", "Bucketlist.pdf");
        }

        private string GetBucketListHtml()
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            var bucketListUserMovies = _db.BucketLists.Where(m => m.AppUserId == user!.Id).ToList();
            var movies = new List<Movie>();
            var AllMovies = _db.Movies.ToList();

            foreach (var movie in bucketListUserMovies)
                movies.Add(AllMovies.First(m => m.Id == movie.MovieId));

            var sb = new StringBuilder();

            sb.Append("<div class=\"row\">");
            sb.Append("<div class=\"col-6\">");
            sb.Append("<h2 class=\"text-primary\">Bucketlist</h2>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class=\"p-4 border rounded\">");

            if (movies.Count() > 0 && movies is not null)
            {
                sb.Append("<table class=\"table table-striped border\">");
                sb.Append("<tr class=\"table-secondary\">");
                sb.Append("<th>Title</th>");
                sb.Append("<th>Minimum age</th>");
                sb.Append("<th>Release year</th>");
                sb.Append("<th>Genre</th>");
                sb.Append("<th></th>");
                sb.Append("</tr>");

                foreach (var movie in movies)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{movie.Title}</td>");
                    sb.Append($"<td>{movie.MinimumAge}</td>");
                    sb.Append($"<td>{movie.GetYear(movie.ReleaseDate)}</td>");
                    sb.Append($"<td>{movie.Category}</td>");
                    sb.Append("<td>");
                    sb.Append("<div class=\"text-center\">");
                    sb.Append("</div>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
            }

            sb.Append("</div>");

            return sb.ToString();
        }

        private string GetBucketListCss()
        {
            // Default CSS styles for the classes
            string defaultStyles = @"
        .row {
            display: flex;
            flex-wrap: wrap;
            margin-right: -15px;
            margin-left: -15px;
        }
        .col-6 {
  flex-basis: 50%;
  max-width: 50%;
}

.text-primary {
  color: #007bff;
}

.p-4 {
  padding: 1rem;
}

.border {
  border: 1px solid #dee2e6;
}

.rounded {
  border-radius: 0.25rem;
}

.table {
  width: 100%;
  margin-bottom: 1rem;
  color: #212529;
}

.table-striped {
  background-color: rgba(0, 0, 0, 0.05);
}

.table-secondary {
  background-color: #f8f9fa;
}
    ";
            //string customStyles = ".custom-class { /* Custom styles for .custom-class */ }";

            string cssContent = $"{defaultStyles}";

            return cssContent;
        }

        #region AddComment
        [HttpPost]
        public IActionResult Comment(MovieDetailsViewModel model)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            if (string.IsNullOrEmpty(model.Comment))
                return RedirectToAction("MovieDetails", new { movieId = model.Id });

            var comment = new MovieComment()
            {
                MovieId = model.Id,
                AppUserId = user.Id,
                Text = model.Comment,
                PostedTime = DateTime.Now
            };

            _db.MovieComments.Add(comment);
            _db.SaveChanges();

            return RedirectToAction("MovieDetails", new { movieId = comment.MovieId });
        }
        #endregion

        #region OtherFuncs
        private string GetIdFromYoutubeUrl(string url)
        {
            string[] separatedUrl = url.Split('=');
            return separatedUrl[1];
        }

        private string ChangePicturePath(string path)
        {
            List<string> separatedPath = path.Split('\\').ToList();
            if (separatedPath.Last().Contains("emptyProfilePicture"))
            {
                return path = "~/" + separatedPath.Last();
            }
            else
            {
                return path = "~/" + separatedPath[separatedPath.Count - 2] + "/" + separatedPath[separatedPath.Count - 1];
            }
        }
        #endregion
    }
}
