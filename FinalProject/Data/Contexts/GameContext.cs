using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
	public class GameContext : DbContext
	{
		public GameContext(DbContextOptions<GameContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Game>().HasData(new Game
			{
				Id = 1,
				Title = "Pac-Man",
				ReleaseDate = new System.DateTime(1980, 5, 22),
				Rating = "Everyone",
				Developer = "Namco"
			});
		}

		public DbSet<Game> Games { get; set; }
	}
}
