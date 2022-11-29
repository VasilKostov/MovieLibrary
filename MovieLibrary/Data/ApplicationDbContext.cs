using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.Models;
using Movie = MovieLibrary.Models.Movie;

namespace MovieLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().Property(p => p.FirstName);
            builder.Entity<AppUser>().Property(p => p.LastName);
            builder.Entity<AppUser>().Ignore(p => p.RoleId);
            builder.Entity<AppUser>().Ignore(p => p.Role);
            builder.Entity<AppUser>().Ignore(p => p.RoleList);
            builder.Entity<Movie>().Property(p => p.Id);
        }


    }
}
