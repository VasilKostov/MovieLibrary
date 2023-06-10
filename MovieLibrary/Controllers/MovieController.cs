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
        #endregion

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
        public async Task<IActionResult> Update(Movie movie)
        {
            var movieToUpdate = _db.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (movieToUpdate == null)
            {
                throw new Exception("No such movie could be found!");
            }

            if (movie.PosterFile == null)
            {
                movieToUpdate.PosterSource = movieToUpdate.PosterSource;
            }
            else if (movie.PosterFile.Length > 0 && movie.PosterFile != null)
            {
                var deletePath = "wwwroot" + movieToUpdate.PosterSource.Substring(1);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/posters", movie.PosterFile.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    await movie.PosterFile.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB  
                    if (memoryStream.Length < 2097152)
                    {
                        movieToUpdate.PosterSource = ChangePicturePath(path);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "The file is too large. It must be under 2 MB");
                    }
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

            _db.SaveChanges();
            IEnumerable<Movie_MovieAward> movieAwards = _db.Movie_MovieAwards;
            IEnumerable<Actor_Movie> movieActors = _db.Actors_Movies;
            _db.RemoveRange(movieAwards.Where(a => a.MovieId == movie.Id));
            _db.RemoveRange(movieActors.Where(a => a.MovieId == movie.Id));

            foreach (var awardId in movie.SelectedMovieAwardsIds)
            {
                var newMovieWithAwards = new Movie_MovieAward()
                {
                    MovieId = movie.Id,
                    MovieAwardId = awardId
                };
                _db.Movie_MovieAwards.Add(newMovieWithAwards);
                _db.SaveChanges();
            }
            foreach (var actorId in movie.SelectedMovieActorsIds)
            {
                var newMovieWithActor = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                _db.Actors_Movies.Add(newMovieWithActor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        #region DeleteMovie
        [HttpPost]
        public IActionResult Delete(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return View("Error", "Nullable exception in Movies");

            var movie = _db.Movies.FirstOrDefault(u => u.Id == movieId);

            if (movie is null)
                return View("Error", "Nullable exception in Movies");

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

        #region Favourit
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

        [HttpGet]
        public IActionResult BucketList()
        {
            AppUser user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity.Name);
            List<BucketList> bucketListUserMovies = _db.BucketLists.Where(m => m.AppUserId == user.Id).ToList();
            List<Movie> movies = new List<Movie>();
            List<Movie> AllMovies = _db.Movies.ToList();
            foreach (var movie in bucketListUserMovies)
            {
                movies.Add(AllMovies.FirstOrDefault(m => m.Id == movie.MovieId));
            }
            return View(movies);
        }

        [HttpPost]
        public IActionResult BucketList(int movieId)
        {
            AppUser user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity.Name);
            BucketList bucketListToAdd = new BucketList()
            {
                MovieId = movieId,
                AppUserId = user.Id
            };
            if (_db.BucketLists.Contains(bucketListToAdd))
            {
                return RedirectToAction(nameof(AllMoviesDetails));
            }
            _db.BucketLists.Add(bucketListToAdd);
            _db.SaveChanges();
            return RedirectToAction(nameof(AllMoviesDetails));
        }

        [HttpGet]
        public IActionResult ConvertBucketListToPDf()
        {
            ////var Renderer = new HtmlToPdf();
            ////Renderer.LoginCredentials.EnableCookies = true;
            ////Renderer.LoginCredentials.NetworkUsername = "admin@admin.bg";
            ////Renderer.LoginCredentials.NetworkPassword = "Admin123#";
            ////Renderer.LoginCredentials.LoginFormUrl = new Uri("https://localhost:7192/Account/Login");
            ////using var PDF = Renderer.RenderUrlAsPdf("https://localhost:7192/Movie/BucketList");
            ////var contentLength = PDF.BinaryData.Length;

            ////Response.Headers["Content-Length"] = contentLength.ToString();
            ////Response.Headers.Add("Content-Disposition", "inline; filename=Document_"+".pdf");

            ////return File(PDF.BinaryData, "application/pdf;");
            //var uri = new Uri("https://localhost:7192/Movie/BucketList");
            //var urlToPdf = new ChromePdfRenderer
            //{
            //    RenderingOptions = new ChromePdfRenderOptions()
            //    {
            //        MarginTop = 50,
            //        MarginBottom = 50,
            //        CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print
            //    },

            //    // setting login credentials to bypass basic authentication
            //    LoginCredentials = new IronPdf.ChromeHttpLoginCredentials
            //    {
            //        NetworkUsername = "admin@admin.bg",
            //        NetworkPassword = "Admin123#",
            //        LoginFormUrl = new Uri("https://localhost:7192/Account/Login")
            //    }
            //};

            //var pdf = urlToPdf.RenderUrlAsPdf(uri);
            //pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfExample2.Pdf"));
            return View("BucketList");
        }

        public IActionResult Calendar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Comment(MovieDetailsViewModel model)
        {
            AppUser user = _db.AppUser.FirstOrDefault(u => u.UserName == User.Identity.Name);
            MovieComment comment = new MovieComment()
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
    }
}
