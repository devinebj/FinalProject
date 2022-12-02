using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>().HasData(new User
			{
				Id = 1,
				UserName = "Player256",
				Password = "P@ssW0rd",
				Email = "player256@finalproject.net",
				DateJoined = System.DateTime.Today
			});
		}
		
		public DbSet<User> Users { get; set; }
	}
}
