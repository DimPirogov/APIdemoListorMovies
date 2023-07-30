using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<MovieList>? MovieLists { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieList>()
            .HasMany(ml => ml.Movies)
            .WithOne(m => m.MovieList)
            .HasForeignKey(m => m.MovieListId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
        // filling the table
        modelBuilder.Entity<MovieList>().HasData(
            new MovieList
            {
                Id = 100,
                Date = new DateTime(2014, 02, 15),
                Name = "First List",
            });
        modelBuilder.Entity<MovieList>().HasData(
            new MovieList
            {
                Id = 101,
                Date = new DateTime(2023, 07, 24),
                Name = "Second List",
            });
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Date = new DateTime(2014, 02, 15),
                Name = "Hellraiser",
                MovieListId = 100
            });
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 2,
                Date = new DateTime(2023, 07, 24),
                Name = "Oppenheimer",
                MovieListId = 101
            });

    }

}