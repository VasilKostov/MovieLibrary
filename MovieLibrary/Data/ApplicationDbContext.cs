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
        public List<MovieComment> MovieComments { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public List<Movie_MovieAward> Movie_MovieAwards { get; set; }
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
                PasswordHash = hasher.HashPassword(null, "Admin123#")
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<MovieAward>().HasData(
                new MovieAward { Id = 1, Name = "Emmy" },
                new MovieAward { Id = 2, Name = "Golden Globe" },
                new MovieAward { Id = 3, Name = "Academy Award (Oscar)" },
                new MovieAward { Id = 4, Name = "European Film Award" },
                new MovieAward { Id = 5, Name = "British Academy Film Award" },
                new MovieAward { Id = 6, Name = "Filmfare Award" },
                new MovieAward { Id = 7, Name = "Critics' Choice Movie" },
                new MovieAward { Id = 8, Name = "Best Feature Film" });

            builder.Entity<ActorAward>().HasData(
                new ActorAward { Id = 1, Name = "Best Actress" },
                new ActorAward { Id = 2, Name = "Screen Actors Guild Award" },
                new ActorAward { Id = 3, Name = "Academy Award (Oscar)" },
                new ActorAward { Id = 4, Name = "European Film Award" },
                new ActorAward { Id = 5, Name = "Best Actor" });

            builder.Entity<Movie>().Property(m => m.Category).HasConversion(c => c.ToString(), c => (MovieCategory)Enum.Parse(typeof(MovieCategory), c));
            builder.Entity<Actor>().Property(m => m.Gender).HasConversion(g => g.ToString(), g => (ActorGender)Enum.Parse(typeof(ActorGender), g));


            builder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });
            builder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.ActorsMovies);
            builder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.ActorsMovies);

            builder.Entity<Actor_ActorAward>().HasKey(am => new { am.ActorId, am.ActorAwardId });
            builder.Entity<Actor_ActorAward>().HasOne(m => m.Actor).WithMany(m => m.Actor_ActorAwards);
            builder.Entity<Actor_ActorAward>().HasOne(a => a.ActorAward).WithMany(am => am.Actor_ActorAwards);

            builder.Entity<Movie_MovieAward>().HasKey(am => new { am.MovieAwardId, am.MovieId });
            builder.Entity<Movie_MovieAward>().HasOne(m => m.Movie).WithMany(am => am.Movie_MovieAwards);
            builder.Entity<Movie_MovieAward>().HasOne(a => a.MovieAward).WithMany(am => am.Movie_MovieAwards);
        }
    }
}
