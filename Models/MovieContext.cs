using Microsoft.EntityFrameworkCore;
namespace Movies.Models
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenereId = "D", GenereName="Drama"},
                new Genre() { GenereId = "R", GenereName = "Romance" },
                new Genre() { GenereId = "T", GenereName = "Thriller" });

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name="The GodFather", Rating=3, Year=2005, GenreId="D" },
                new Movie() { MovieId = 2, Name = "The Avataar", Rating = 5, Year = 2004, GenreId = "D"},
                new Movie() { MovieId = 3, Name = "The GhostRider", Rating = 4, Year = 2010, GenreId = "T"},
                new Movie() { MovieId = 4, Name = "Venom", Rating = 4, Year = 2020, GenreId = "R"});
        }
    }
}
