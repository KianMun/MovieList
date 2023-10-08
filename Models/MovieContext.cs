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

		//Seeding initial Movie data
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().HasData(
				new Movie
				{
					MovieId = 1,
					Name = "The Test",
					Year = 1953,
					Rating = 5
				},
				new Movie
				{
					MovieId = 2,
					Name = "Test Movie",
					Year = 1963,
					Rating = 4
				},new Movie
				{
					MovieId = 3,
					Name = "Test",
					Year = 1973,
					Rating = 3
				}
				) ;
		}
	}
}
