using Microsoft.EntityFrameworkCore;
using Moq;
using MovieLibrary.Contracts;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.Services;

namespace MovieLibraryTest
{
    public class Tests
    {
        private ApplicationDbContext db;
        private MovieService MService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseSqlServer("Data Source=.;Initial Catalog=ProjectTestSeed;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
           .Options;

            // Create the ApplicationDbContext using the existing database connection
            db = new ApplicationDbContext(options);

            // Create an instance of the MovieService using the ApplicationDbContext
            MService = new MovieService(db);
        }

        [Test]
        public async Task AllMovieTest()
        {
            //From seeded data
            //Arange
            var movieId = 1;

            //Act
            var movie = await MService.GetMovieById(movieId);

            //Assert
            Assert.IsTrue(movie!.Id == movieId);
        }

        [Test]
        public async Task GetActorsByMovieId()
        {
            //From seeded data
            // Arrange
            var movieId = 1;

            // Act
            var actors = await MService.GetActors(movieId);

            // Assert
            Assert.IsNotNull(actors);
            Assert.That(actors.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetCommentByMovieId()
        {
            //From seeded data
            // Arrange
            var movieId = 1;

            // Act
            var comments = await MService.GetCommentByMovieId(movieId);

            // Assert
            Assert.IsNotNull(comments);
            Assert.That(comments.Where(c => c.Id == 2).First().AppUserId, Is.EqualTo("02174cf0–9412–4cfe - afbf - 59f706d72cf6"));
        }

        [Test]
        public async Task GetAwardsTest()
        {
            // Arrange
            var award = new MovieAward { Name = "Test" };
            await db.MovieAwards.AddAsync(award);
            await db.SaveChangesAsync();

            // Act
            var newAward = MService.GetAwards().Result.Where(a => a.Name == award.Name).First();

            // Assert
            Assert.IsNotNull(newAward);
            Assert.That(award.Name, Is.EqualTo(newAward.Name));

            db.Remove(newAward);
            await db.SaveChangesAsync();
        }

        [Test]
        public async Task CreateMovieTest()
        {
            //Arrange
            var movie = new Movie
            {
                Title = "Test",
                ReleaseDate = new DateTime(1914, 01, 01),
                ProducerId = 1,
                Accepted = false
            };

            //Act
            await MService.CreateMovie(movie);
            var newMovie = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == movie.ReleaseDate && m.Title == movie.Title).FirstOrDefault();

            //Assert
            Assert.IsNotNull(newMovie);
            Assert.That(newMovie.Title, Is.EqualTo(movie.Title));
        }

        [Test]
        public async Task MovieALreadyExistTest()
        {
            //Arragne
            //From seed
            var movie = await MService.GetMovieById(1);
            //Act
            var result = await MService.MovieAlereadyExists(movie!);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteMovieTest()
        {
            //Arrange
            var date = new DateTime(1914, 01, 01);
            var title = "Test";

            //Act
            var newMovie = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == date && m.Title == title).FirstOrDefault();
            await MService.DeleteMovie(newMovie);
            var delMovie = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == date && m.Title == title).FirstOrDefault();
            //Assert
            Assert.IsNull(delMovie);
        }

        [Test]
        public async Task GetProducerByIdTest()
        {
            // Arrange
            var producer = new Producer { Name = "Test Test" };
            await db.Producers.AddAsync(producer);
            await db.SaveChangesAsync();

            // Act
            //Here we get them all because i cannot insert actor with id e.i 2000
            var expProducer = MService.GetProducers().Result.Where(a => a.Name == "Test Test").FirstOrDefault();
            var expProducer2 = await MService.GetProducer(expProducer!.Id);

            // Assert
            Assert.IsNotNull(expProducer);
            Assert.That(producer.Name, Is.EqualTo(expProducer2!.Name));

            db.Remove(expProducer);
            await db.SaveChangesAsync();
        }

        [Test]
        public async Task GetActorByIdTest()
        {
            // Arrange
            var actor = new Actor { FirstName = "Test", LastName = "Test", Gender = ActorGender.Male };
            await db.Actors.AddAsync(actor);
            await db.SaveChangesAsync();

            // Act
            //Here we get them all because i cannot insert actor with id e.i 2000
            var result = await MService.GetActors();
            var expectedActor = result.Where(a => a.FirstName == "Test").FirstOrDefault();

            var expectedActor2 = await MService.GetActor(expectedActor!.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(actor.FirstName, Is.EqualTo(expectedActor2!.FirstName));

            db.Remove(expectedActor);
            await db.SaveChangesAsync();
        }

        [Test]
        public async Task GetAllMoviesTest()
        {
            //Arrange
            var user = new AppUser
            {
                Age = 18
            };

            //Act
            var movies = await MService.GetAllMovies(user);
            var ok = true;
            foreach (var movie in movies)
                if (movie.MinimumAge > user.Age)
                    ok = false;

            //Assert
            Assert.IsTrue(ok);
        }

        [Test]
        public async Task GetMoviesTest()
        {

            //Act
            var movies = await MService.GetMovies();

            //Assert
            Assert.IsNotNull(movies);
        }

        [Test]
        public async Task GetMovieCreatorsRoleTest()
        {
            //Arrange
            var movie = await MService.GetMovieById(1);
            var movies = new List<Movie> { movie };

            //Act
            var result = await MService.SetMovieAndRole(movies);

            //Assert
            Assert.IsTrue(result![0].Item1 == "Admin");
        }

        [Test]
        public async Task GetCreatorsRoleTest()
        {
            //Arrange
            var userId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";

            //Act
            var result = await MService.GetCreatorsRole(userId);

            //Assert
            Assert.IsTrue(result == "Admin");
        }

        [Test]
        public async Task GetCommentByIdTest()
        {
            //Arrange
            var commentId = 2;

            //Act
            var result = await MService.GetComment(commentId);

            //Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public async Task AddCommentTest()
        {
            //Arrange
            var comment = new MovieComment
            {
                Text = "Test",
                AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                MovieId = 1,
                PostedTime = new DateTime(1920, 01, 01)
            };

            //Act
            await MService.AddComment(comment);
            var newComment = MService.GetCommentByMovieId(1).Result!.Where(c => c.Text == comment.Text).First();

            //Assert
            Assert.IsNotNull(newComment);
        }


        [Test]
        public async Task DeleteCommentTest()
        {
            //Arrange
            var text = "Test";
            var date = new DateTime(1920, 01, 01);

            //Act
            var newComment = MService.GetCommentByMovieId(1).Result!.Where(c => c.Text == text && c.PostedTime == date).First();
            await MService.DeleteComment(newComment);
            var delComment = MService.GetCommentByMovieId(1).Result!.Where(c => c.Text == text && c.PostedTime == date).FirstOrDefault();

            //Assert
            Assert.IsNull(delComment);
        }


        [Test]
        public async Task GetAwardByIdTest()
        {
            //Arrange
            //From seeded data
            var awardId = 1;

            //Act
            var result = await MService.GetMovieAward(awardId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetM_MAwardsTest()
        {
            //Arrange
            //From seeded data
            var movieId = 1;

            //Act
            var result = await MService.GetMovie_MovieAwards(movieId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetMovieActorsTest()
        {
            //Arrange
            //From seeded data
            var movieId = 1;

            //Act
            var result = await MService.GetMovieActors(movieId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateMovieAccTest()
        {
            //Arrange
            var movie = new Movie
            {
                Title = "Test",
                ReleaseDate = new DateTime(1915, 01, 01),
                ProducerId = 1,
                Accepted = false
            };

            //Act
            await MService.CreateMovie(movie);
            var movies = await MService.GetMovies(false);
            var newMovie = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == movie.ReleaseDate && m.Title == movie.Title).FirstOrDefault();
            await MService.UpdateMovie(newMovie!.Id);
            var newMovieAcc = MService.GetMovies(true).Result?.Where(m => m.ReleaseDate == movie.ReleaseDate && m.Title == movie.Title).FirstOrDefault();
            await MService.DeleteMovie(newMovieAcc);

            //Assert
            Assert.IsTrue(newMovieAcc!.Accepted);
        }

        [Test]
        public async Task UpdateMovieTest()
        {
            //Arrange
            var movie = new Movie
            {
                Title = "Test",
                ReleaseDate = new DateTime(1915, 01, 01),
                ProducerId = 1,
                Accepted = false
            };

            //Act
            await MService.CreateMovie(movie);
            var newMovie = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == movie.ReleaseDate && m.Title == movie.Title).FirstOrDefault();
            newMovie!.Title = "Test1";
            await MService.UpdateMovie(newMovie);
            var newMovieAcc = MService.GetMovies(false).Result?.Where(m => m.ReleaseDate == movie.ReleaseDate && m.Title == movie.Title).FirstOrDefault();
            await MService.DeleteMovie(newMovieAcc);

            //Assert
            Assert.IsTrue(newMovieAcc!.Title == "Test1");
        }

        [Test]
        public async Task GetAwardsByIdTest()
        {
            // Arrange
            //From seeded data
            var movieId = 1;

            // Act
            var newAward = await MService.GetAwards(movieId);

            // Assert
            Assert.IsNotNull(newAward);
        }

        [Test]
        public async Task AddFevouriteTest()
        {
            // Arrange
            var fav = new Favourite
            {
                MovieId = 1,
                AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6"
            };

            // Act
            await MService.AddFavourites(fav);
            var newFav = await MService.GetFavourite(1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
            // Assert
            Assert.IsNotNull(newFav);
        }

        [Test]
        public async Task GetFavouriteTest()
        {
            //Act
            var favs = await MService.GetFavorites("02174cf0–9412–4cfe - afbf - 59f706d72cf6");
            var fav = favs!.Where(f => f.MovieId == 1).FirstOrDefault();

            //Assert
            Assert.IsNotNull(fav);
        }

        [Test]
        public async Task IsInFavTest()
        {
            //Arrange
            var fav = await MService.GetFavourite(1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6");

            //Act
            var result = await MService.IsInFavourites(fav);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetFavMovie()
        {
            //Arrange
            var movieId = 1;

            //Act
            var movies = await MService.GetUserFavorites("02174cf0–9412–4cfe - afbf - 59f706d72cf6");
            var movie = movies.Where(m=>m.Id == movieId).FirstOrDefault();

            //Assert
            Assert.IsNotNull(movie);
        }

        [Test]
        public async Task RemoveFavTest()
        {
            //Act
            await MService.RemoveFavourite(1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
            var newFav = await MService.GetFavourite(1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6");

            //Assert
            Assert.IsNull(newFav);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the ApplicationDbContext
            db.Dispose();
        }
    }
}