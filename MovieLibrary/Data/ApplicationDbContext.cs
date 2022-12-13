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
        public DbSet<Actor_ActorAward> Actor_ActorAwards { get; set; }
        public DbSet<ActorAward> ActorAwards { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
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

            //builder.Entity<AppUser>().Property(p => p.FirstName);
            //builder.Entity<AppUser>().Property(p => p.LastName);
            //builder.Entity<AppUser>().Ignore(p => p.RoleId);
            //builder.Entity<AppUser>().Ignore(p => p.Role);
            //builder.Entity<AppUser>().Ignore(p => p.RoleList);
            //builder.Entity<Movie>().Property(p => p.Id);

            builder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });
            builder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.ActorsMovies);
            builder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.ActorsMovies);

            builder.Entity<Actor_ActorAward>().HasKey(am => new { am.ActorId, am.ActorAwardId });
            builder.Entity<Actor_ActorAward>().HasOne(m => m.Actor).WithMany(m => m.Actor_ActorAwards);
            builder.Entity<Actor_ActorAward>().HasOne(a => a.ActorAward).WithMany(am => am.Actor_ActorAwards);

            builder.Entity<Movie_MovieAward>().HasKey(am => new { am.MovieAwardId, am.MovieId });
            builder.Entity<Movie_MovieAward>().HasOne(m => m.Movie).WithMany(am => am.Movie_MovieAwards);
            builder.Entity<Movie_MovieAward>().HasOne(a => a.MovieAward).WithMany(am => am.Movie_MovieAwards);

            //builder.Entity<MovieComment>().HasKey(am => new { am.MovieId, am.UserId });
            builder.Entity<MovieComment>().HasOne(m => m.AppUser).WithMany(am => am.CommentsOnMovies).HasForeignKey("UserId");
            builder.Entity<MovieComment>().HasOne(a => a.Movie).WithMany(am => am.CommentsOnMovies).HasForeignKey("MovieId");
        }
    }
}
