using FinalProject.Data;
using FinalProject.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalProject
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerDocument();
			services.AddDbContext<NameContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("Context")));
			services.AddScoped<INameContextDAO, NameContextDAO>();

			services.AddDbContext<CarContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("Context")));
			services.AddScoped<ICarContextDAO, CarContextDAO>();

			services.AddDbContext<GameContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("Context")));
			services.AddScoped<IGameContextDAO, GameContextDAO>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,	GameContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseOpenApi();
			app.UseSwaggerUi3();
			context.Database.Migrate();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
