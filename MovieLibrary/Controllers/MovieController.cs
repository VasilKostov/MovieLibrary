using Grpc.Core;
using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieLibrary.Contracts;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.Singleton;
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
    public class MovieController : BaseController
    {
        private readonly IMovieService MService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MovieController(IWebHostEnvironment webHostEnvironment, IMovieService movieService)
        {
            _webHostEnvironment = webHostEnvironment;
            MService = movieService;
        }

        #region Movies
        [HttpGet]
        public async Task<IActionResult> AllMovies()
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var movies = await MService.GetAllMovies(user);

            return View(movies);
        }
        #endregion

        #region Movie
        [HttpGet]
        public async Task<IActionResult> MovieDetails(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var movie = await MService.GetMovieById((int)movieId);

            if (movie is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullMovie });

            var comments = await MService.GetCommentByMovieId(movie.Id);

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

        #region MovieList
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MovieList()
        {
            var movies = await MService.GetMovies();
            var model = await MService.SetMovieAndRole(movies);

            return View(model);
        }
        #endregion

        #region CreateMovie
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateMovieViewModel();

            var awards = await MService.GetAwards();
            var producers = await MService.GetProducers();
            var actors = await MService.GetActors();

            model.AllMovieAwards = new SelectList(awards, "Id", "Name").ToList();
            model.AllProducers = new SelectList(producers, "Id", "Name").ToList();
            model.AllMovieActors = new SelectList(actors, "Id", "FullName").ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel model)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

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

            await MService.CreateMovie(newMovie);
            await MService.AddMovieAwards(model.SelectedMovieAwardsIds, newMovie.Id);
            await MService.AddActors(model.SelectedMovieActorsIds, newMovie.Id);

            return RedirectToAction("Create");
        }
        #endregion

        #region UpdateMovie
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> Update(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var movie = await MService.GetMovieById((int)movieId);
            var allmovieAwards = await MService.GetAwards();
            var allmovieProducers = await MService.GetProducers();
            var allmovieActors = await MService.GetActors();

            if (movie is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullMovie });

            //Getting actors, producer and awards which are already in the movie
            var movieActors = await MService.GetActors(movie.Id);
            var movieAwards = await MService.GetAwards(movie.Id);
            var movieProducer = await MService.GetProducer(movie.ProducerId);

            var model = new UpdateMovieViewModel()
            {
                Movie = movie,
                Producer = movieProducer,
                Awards = movieAwards,
                Actors = movieActors,
                AllMovieAwards = new SelectList(allmovieAwards, "Id", "Name").ToList(),
                AllMovieActors = new SelectList(allmovieActors, "Id", "FullName").ToList(),
                AllProducers = new SelectList(allmovieProducers, "Id", "Name").ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateMovieViewModel model)
        {
            var movie = model.Movie;
            var movieToUpdate = await MService.GetMovieById(movie.Id);

            if (movieToUpdate is null || movie is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullMovie });

            if (movie.PosterFile is null)
                movieToUpdate.PosterSource = movieToUpdate.PosterSource;

            else if (movie.PosterFile.Length > 0 && movie.PosterFile is not null)
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

            //If the array of Ids is empty that means that the user wants to leave the movie with the same Actors/Producer
            if (model.SelectedMovieProducerId is not null && model.SelectedMovieProducerId is not 0)
                movieToUpdate.ProducerId = (int)model.SelectedMovieProducerId!;

            //A movie could have zero awards
            if (model.SelectedMovieAwardsIds is not null)
            {
                await MService.RemoveMovieAwards(movieToUpdate.Id);
                await MService.AddMovieAwards(model.SelectedMovieAwardsIds, movieToUpdate.Id);
            }

            if (model.SelectedMovieActorsIds is not null)
            {
                await MService.RemoveMovieActors(movieToUpdate.Id);
                await MService.AddActors(model.SelectedMovieAwardsIds!, movieToUpdate.Id);
            }

            return RedirectToAction("MovieList");
        }
        #endregion

        #region DeleteMovie
        [HttpPost]
        public async Task<IActionResult> Delete(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var movie = await MService.GetMovieById((int)movieId);

            if (movie is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullMovie });

            //Delete poster from files
            if (movie.PosterSource is not null)
            {
                var deletePath = "wwwroot" + movie.PosterSource.Substring(1);
                if (System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);
            }

            await MService.DeleteMovie(movie);

            return RedirectToAction("MovieList");
        }
        #endregion

        #region DeleteComment
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int? commentId)
        {
            if (commentId is null || commentId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var comment = await MService.GetComment((int)commentId);

            if (comment is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullComment });

            await MService.DeleteComment(comment);

            return RedirectToAction("MovieDetails", new { movieId = comment.MovieId });
        }
        #endregion

        #region Accept
        [HttpGet]
        public async Task<IActionResult> Accept()
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var movies = await MService.GetMovies(false);

            return View(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var movie = await MService.GetMovieById((int)movieId);

            if (movie is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullMovie });

            movie.Accepted = true;

            await MService.UpdateMovie(movie.Id);

            return RedirectToAction("Accept");
        }
        #endregion

        #region Favourite
        [HttpGet]
        public async Task<IActionResult> Favourite()
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var movies = await MService.GetUserFavorites(user.Id);

            return View(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Favourite(int movieId)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var favouriteMovieToAdd = new Favourite()
            {
                MovieId = movieId,
                AppUserId = user.Id
            };

            if (await MService.IsInFavourites(favouriteMovieToAdd))
                return RedirectToAction("AllMovies");

            await MService.AddFavourites(favouriteMovieToAdd);

            return RedirectToAction("AllMovies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavourite(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            await MService.RemoveFavourite((int)movieId, user.Id);

            return RedirectToAction("Favourite");
        }
        #endregion

        #region Bucketlist
        [HttpGet]
        public async Task<IActionResult> BucketList()
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });
            var movies = await MService.GetBucketMovies(GetUserId());

            return View(movies);
        }

        [HttpPost]
        public async Task<IActionResult> BucketList(int movieId)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var bucketListToAdd = new BucketList()
            {
                MovieId = movieId,
                AppUserId = user.Id
            };

            if (await MService.IsInBucketList(bucketListToAdd))
                return RedirectToAction("AllMovies");

            await MService.AddBucket(bucketListToAdd);

            return RedirectToAction("AllMovies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMovieFromBucketList(int? movieId)
        {
            if (movieId is null || movieId is 0)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            await MService.RemoveBucketListMovie((int)movieId, user.Id);

            return RedirectToAction("BucketList");
        }
        #endregion

        #region AddComment
        [HttpPost]
        public async Task<IActionResult> Comment(MovieDetailsViewModel? model)
        {
            if (model is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            if (string.IsNullOrEmpty(model.Comment))
                return RedirectToAction("MovieDetails", new { movieId = model.Id });

            var comment = new MovieComment()
            {
                MovieId = model.Id,
                AppUserId = user.Id,
                Text = model.Comment,
                PostedTime = DateTime.Now
            };

            await MService.AddComment(comment);

            return RedirectToAction("MovieDetails", new { movieId = comment.MovieId });
        }
        #endregion

        #region RateMovie
        [HttpPost]
        public async Task<IActionResult> Rate(int? movieId, int? rate)
        {
            if ((movieId is null or 0) || (rate is null or 0))
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            await MService.RateMovie(movieId, rate);

            return RedirectToAction("MovieDetails", new { movieId = movieId });
        }
        #endregion

        #region SearchMovie
        public async Task<IActionResult> Search(string? data, string viewCaller)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            if (viewCaller is "AllMovies")
            {
                var movies = await MService.GetSearchedMovies(data, user);
                return View("AllMovies", movies);
            }
            else if (viewCaller is "MovieList")
            {
                var movies = await MService.GetSearchedMovies(data);
                var model = await MService.SetMovieAndRole(movies);
                return View("MovieList", model);
            }
            else if (viewCaller is "MovieWaitlist")
            {
                var movies = await MService.GetSearchedAcceptedMovies(data);
                return View("Accept", movies);
            }
            else if (viewCaller is "Bucket")
            {
                var movies = await MService.GetSearchedBucketMovies(data, user);
                return View("BucketList", movies);
            }
            else if (viewCaller is "Favourite")
            {
                var movies = await MService.GetSearchedFavMovies(data, user);
                return View("Favourite", movies);
            }

            return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NoSuchParameter, ErrorMessage = "ERROR: NO SUCH VIEW FOR THE SEARCH FUNC" });
        }
        #endregion

        #region PDFDowloader
        [HttpGet]
        public async Task<IActionResult> ConvertBucketListToPDf()
        {
            var html = await GetBucketListHtml();
            var css = GetBucketListCss();

            string combinedContent = $"<html><head><style>{css}</style></head><body>{html}</body></html>";

            var renderer = new HtmlToPdf();
            var pdf = renderer.RenderHtmlAsPdf(combinedContent);

            return File(pdf.BinaryDataIncremental, "application/pdf", "Bucketlist.pdf");
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
                return path = "~/" + separatedPath.Last();
            else
                return path = "~/" + separatedPath[separatedPath.Count - 2] + "/" + separatedPath[separatedPath.Count - 1];
        }

        private async Task<string> GetBucketListHtml()
        {
            //Will always have user because of authorization policies
            var user = await MService.GetUserById(GetUserId());
            //There will always be movies because the button that triggers this function is only visible when the count is > 0
            var movies = await MService.GetBucketMovies(user!.Id);

            var sb = new StringBuilder();

            sb.Append("<div class=\"row\">");
            sb.Append("<div class=\"col-6\">");
            sb.Append("<h2 class=\"text-primary\">Bucketlist</h2>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class=\"p-4 border rounded\">");

            if (movies!.Count() > 0 && movies is not null)
            {
                sb.Append("<table class=\"table table-striped border\">");
                sb.Append("<tr class=\"table-secondary\">");
                sb.Append("<th>Title</th>");
                sb.Append("<th>Released year</th>");
                sb.Append("<th>Genre</th>");
                sb.Append("<th>Rating</th>");
                sb.Append("<th>Minimum age</th>");
                sb.Append("</tr>");

                foreach (var movie in movies)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{movie.Title}</td>");
                    sb.Append($"<td>{movie.GetYear(movie.ReleaseDate)}</td>");
                    sb.Append($"<td>{movie.Category}</td>");
                    sb.Append($"<td>{movie.Rating}</td>");
                    sb.Append($"<td>{movie.MinimumAge}</td>");
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
            string defaultStyles = @".table {
  width: 100%;
  border-collapse: collapse;
}

.table th,
.table td {
  padding: 10px;
  text-align: left;
  border: 1px solid #ccc;
}

.table th {
  background-color: #f2f2f2;
}

.table tr:nth-child(even) {
  background-color: #f9f9f9;
}

.table tr:hover {
  background-color: #e6e6e6;
}";

            string cssContent = $"{defaultStyles}";

            return cssContent;
        }
        #endregion
    }
}
