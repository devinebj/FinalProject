using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
	public class CarContext : DbContext
	{
		public CarContext(DbContextOptions<CarContext> options) : base(options) { }
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Car>().HasData(new Car
			{
				Id = 1,
				Make = "Jeep",
				Model = "Liberty",
				Year = 2006,
				Color = "Blue"
			});
		}

		public DbSet<Car> Cars { get; set; }
	}
}
