using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.Models;
using System.Reflection.Emit;
using MovieLibrary.Models.Movies;
using MovieLibrary.Models.Relations;
using MovieLibrary.Models.Actors;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public ActorGender ActorGender { get; set; }
        public DbSet<Actor_ActorAward> Actor_ActorAwards { get; set; }
        public DbSet<ActorAward> ActorAwards { get; set; }
        public MovieCategory MovieCategories { get; set; }
        public List<MovieCountry> MovieCountries { get; set; }
        public List<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Movie_MovieAward> Movie_MovieAwards { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<BucketList> BucketLists { get; set; }
        public DbSet<MovieAward> MovieAwards { get; set; }
        public DbSet<Producer> Producers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Roles
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ROLE_ID, ConcurrencyStamp = ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "User", NormalizedName = "USER" });

            //Admin
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.bg",
                NormalizedEmail = "ADMIN@ADMIN.BG",
                Role = "Admin",
                Age = 30,
                PasswordHash = hasher.HashPassword(null, "Admin123#")
            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Margot", LastName = "Robbie", AppUserId = ADMIN_ID, Gender = ActorGender.Female },
                new Actor { Id = 2, FirstName = "Chris", LastName = "Hemsworth", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 3, FirstName = "Golshifteh", LastName = "Farahani", AppUserId = ADMIN_ID, Gender = ActorGender.Female },
                new Actor { Id = 4, FirstName = "Adam", LastName = "Bessa", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 5, FirstName = "Ryder", LastName = "Lerum", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 6, FirstName = "Bryon", LastName = "Lerum", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 7, FirstName = "Keanu", LastName = "Reeves", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 8, FirstName = "Laurence", LastName = "Fishburne", AppUserId = ADMIN_ID, Gender = ActorGender.Female },
                new Actor { Id = 9, FirstName = "George", LastName = "Georgiou", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 10, FirstName = "Tim", LastName = "Robbins", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 11, FirstName = "Morgan", LastName = "Freeman", AppUserId = ADMIN_ID, Gender = ActorGender.Male },
                new Actor { Id = 12, FirstName = "Bob", LastName = "Guton", AppUserId = ADMIN_ID, Gender = ActorGender.Male }
                );

            builder.Entity<Producer>().HasData(
                new Producer { Id = 1, Name = "Quentin Tarantino" },
                new Producer { Id = 2, Name = "Michael Mann" },
                new Producer { Id = 3, Name = "Steven Spielberg" },
                new Producer { Id = 4, Name = "Jerry Bruckheimer" },
                new Producer { Id = 5, Name = "Spike LeeSpike Lee" },
                new Producer { Id = 6, Name = "Irwin Winkler" },
                new Producer { Id = 7, Name = "Dana Brunetti" },
                new Producer { Id = 8, Name = "Kathleen Kennedy" },
                new Producer { Id = 9, Name = "Sam Hargrave" },
                new Producer { Id = 10, Name = "Chad Stahelski" },
                new Producer { Id = 11, Name = "Frank Darabont" }
                );

            builder.Entity<MovieAward>().HasData(
                new MovieAward { Id = 1, Name = "Emmy" },
                new MovieAward { Id = 2, Name = "Golden Globe" },
                new MovieAward { Id = 3, Name = "Academy Award (Oscar)" },
                new MovieAward { Id = 4, Name = "European Film Award" },
                new MovieAward { Id = 5, Name = "British Academy Film Award" },
                new MovieAward { Id = 6, Name = "Filmfare Award" },
                new MovieAward { Id = 7, Name = "Critics' Choice Movie" },
                new MovieAward { Id = 8, Name = "Best Feature Film" }
                );

            builder.Entity<ActorAward>().HasData(
                new ActorAward { Id = 1, Name = "Best Actress" },
                new ActorAward { Id = 2, Name = "Screen Actors Guild Award" },
                new ActorAward { Id = 3, Name = "Academy Award (Oscar)" },
                new ActorAward { Id = 4, Name = "European Film Award" },
                new ActorAward { Id = 5, Name = "Best Actor" }
                );

            builder.Entity<Actor_ActorAward>().HasData(
                new Actor_ActorAward { ActorAwardId = 1, ActorId = 1 },
                new Actor_ActorAward { ActorAwardId = 2, ActorId = 11 }
                );

            builder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Extraction", Budget = 100000000, ReleaseDate = new DateTime(2020, 1, 1), MinimumAge = 18, Rating = 0, UsersRated = 0, Description = "Tyler Rake, a fearless black market mercenary, embarks on the most deadly extraction of his career when he's enlisted to rescue the kidnapped son of an imprisoned international crime lord.", ProducerId = 9, Category = MovieCategory.Action, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", AppUserEmail = "admin@admin.bg", PosterSource = "~/images/posters/extraction2020.jpg", Accepted = true, TrailerUrl = "L6P3nI6VnlY" },
                new Movie { Id = 2, Title = "Extraction 2", Budget = 300000000, ReleaseDate = new DateTime(2023, 1, 1), MinimumAge = 18, Rating = 0, UsersRated = 0, Description = "After barely surviving his grievous wounds from his mission in Dhaka, Bangladesh, Tyler Rake is back, and his team is ready to take on their next mission.", ProducerId = 9, Category = MovieCategory.Action, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", AppUserEmail = "admin@admin.bg", PosterSource = "~/images/posters/extraction2023.jpg", Accepted = true, TrailerUrl = "Y274jZs5s7s" },
                new Movie { Id = 3, Title = "John Wick: Chapter 4", Budget = 450000000, ReleaseDate = new DateTime(2023, 1, 1), MinimumAge = 18, Rating = 0, UsersRated = 0, Description = "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.", ProducerId = 10, Category = MovieCategory.Action, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", AppUserEmail = "admin@admin.bg", PosterSource = "~/images/posters/johnwich4.jpeg", Accepted = true, TrailerUrl = "qEVUtrk8_B4" },
                new Movie { Id = 4, Title = "The Shawshank Redemption", Budget = 990000000, ReleaseDate = new DateTime(1994, 1, 1), MinimumAge = 16, Rating = 4.7, UsersRated = 1000, Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", ProducerId = 11, Category = MovieCategory.Western, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", AppUserEmail = "admin@admin.bg", PosterSource = "~/images/posters/shawshank.jpg", Accepted = true, TrailerUrl = "6hB3S9bIaco" }
                );

            builder.Entity<Movie_MovieAward>().HasData(
                new Movie_MovieAward { MovieAwardId = 3, MovieId = 4 }
                );

            builder.Entity<Actor_Movie>().HasData(
                new Actor_Movie { ActorId = 2, MovieId = 2 },
                new Actor_Movie { ActorId = 3, MovieId = 2 },
                new Actor_Movie { ActorId = 4, MovieId = 2 },
                new Actor_Movie { ActorId = 2, MovieId = 1 },
                new Actor_Movie { ActorId = 5, MovieId = 1 },
                new Actor_Movie { ActorId = 6, MovieId = 1 },
                new Actor_Movie { ActorId = 7, MovieId = 3 },
                new Actor_Movie { ActorId = 8, MovieId = 3 },
                new Actor_Movie { ActorId = 9, MovieId = 3 },
                new Actor_Movie { ActorId = 10, MovieId = 4 },
                new Actor_Movie { ActorId = 11, MovieId = 4 },
                new Actor_Movie { ActorId = 12, MovieId = 4 }
                );

            builder.Entity<MovieComment>().HasData(
                new MovieComment { Id = 1, MovieId = 1, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", Text = "Very good movie!", PostedTime = DateTime.UtcNow },
                new MovieComment { Id = 2, MovieId = 1, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", Text = "I can agree too", PostedTime = DateTime.UtcNow },
                new MovieComment { Id = 3, MovieId = 1, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", Text = "I want to watch the next one", PostedTime = DateTime.UtcNow },
                new MovieComment { Id = 4, MovieId = 2, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", Text = "I dont like it that much", PostedTime = DateTime.UtcNow },
                new MovieComment { Id = 5, MovieId = 3, AppUserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6", Text = "Sadly its the last movie from the series", PostedTime = DateTime.UtcNow }
            );

            builder.Entity<Movie>().Property(m => m.Category).HasConversion(c => c.ToString(), c => (MovieCategory)Enum.Parse(typeof(MovieCategory), c));
            builder.Entity<Actor>().Property(m => m.Gender).HasConversion(g => g.ToString(), g => (ActorGender)Enum.Parse(typeof(ActorGender), g));

            builder.Entity<AppUser>().HasMany(c => c.Movies).WithOne(e => e.AppUser);
            builder.Entity<AppUser>().HasMany(c => c.Actors).WithOne(e => e.AppUser);

            builder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });
            builder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.ActorsMovies);
            builder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.ActorsMovies);

            builder.Entity<Actor_ActorAward>().HasKey(am => new { am.ActorId, am.ActorAwardId });
            builder.Entity<Actor_ActorAward>().HasOne(m => m.Actor).WithMany(m => m.Actor_ActorAwards);
            builder.Entity<Actor_ActorAward>().HasOne(a => a.ActorAward).WithMany(am => am.Actor_ActorAwards);

            builder.Entity<Movie_MovieAward>().HasKey(am => new { am.MovieAwardId, am.MovieId });
            builder.Entity<Movie_MovieAward>().HasOne(m => m.Movie).WithMany(am => am.Movie_MovieAwards);
            builder.Entity<Movie_MovieAward>().HasOne(a => a.MovieAward).WithMany(am => am.Movie_MovieAwards);

            builder.Entity<BucketList>().HasKey(am => new { am.AppUserId, am.MovieId });
            builder.Entity<BucketList>().HasOne(m => m.Movie).WithMany(am => am.BucketLists);
            builder.Entity<BucketList>().HasOne(a => a.AppUser).WithMany(am => am.BucketLists);

            builder.Entity<Favourite>().HasKey(am => new { am.AppUserId, am.MovieId });
            builder.Entity<Favourite>().HasOne(m => m.Movie).WithMany(am => am.Favourites);
            builder.Entity<Favourite>().HasOne(a => a.AppUser).WithMany(am => am.Favourites);
        }
    }
}
