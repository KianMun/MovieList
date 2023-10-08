using Microsoft.EntityFrameworkCore;

namespace MovieList.Models
{
	//MovieContext class that inherits the DbContext class
	public class MovieContext:DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
		{
			
		}
		//DbSet<Entity> work with model class that map to database tables
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }

		//Seeding initial Movie data
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Genre>().HasData(
				new Genre { GenreId = "A", Name = "Action" },
				new Genre { GenreId = "C", Name = "Comedy" },
				new Genre { GenreId = "D", Name = "Drama" },
				new Genre { GenreId = "H", Name = "Horror" },
				new Genre { GenreId = "M", Name = "Musical" },
				new Genre { GenreId = "R", Name = "RomCom" },
				new Genre { GenreId = "S", Name = "SciFi" }

				);

			modelBuilder.Entity<Movie>().HasData(
				new Movie
				{
					MovieId = 1,
					Name = "The Casablanca",
					Year = 1953,
					Rating = 5,
					GenreId ="D"
				},
				new Movie
				{
					MovieId = 2,
					Name = "Test Movie",
					Year = 1963,
					Rating = 4,
                    GenreId = "A"
                },new Movie
				{
					MovieId = 3,
					Name = "2001",
					Year = 1973,
					Rating = 3,
                    GenreId = "S"
                }
				) ;
		}
	}
}
