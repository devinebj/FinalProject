using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
	public class NameContext : DbContext
	{
		public NameContext(DbContextOptions<NameContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Name>().HasData(new Name { 
				Id = 1, 
				name = "Ben Devine", 
				birthdate = new System.DateTime(2000, 12, 14),
				collegeProgram = "IT - Game Design and Software Development",
				yearInProgram = "Senior"
			}); 
		}

		public DbSet<Name> Names { get; set; }
	}
}
