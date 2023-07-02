using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<List> Lists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // filling the table
            modelBuilder.Entity<List>().HasData(
                new List
                {
                    ListId = 1,
                    Date = new DateTime(2014, 02, 15),
                    ListName = "FirstList",
                });
            modelBuilder.Entity<List>().HasData(
                new List
                {
                    ListId = 2,
                    Date = new DateTime(2022, 02, 24),
                    ListName = "SecondList",
                });
        }

    }
}
