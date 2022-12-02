using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GameController : ControllerBase
	{
		private readonly ILogger<GameController> _logger;
		private readonly IGameContextDAO _context;

		public GameController(ILogger<GameController> logger, IGameContextDAO context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllGames()
		{
			return Ok(_context.GetAllGames());
		}

		[HttpGet("id")]
		public IActionResult GetGameById(int id)
		{
			var game = _context.GetGameById(id);
			if (game == null)
				return NotFound(id);

			return Ok(game);
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var result = _context.RemoveGameById(id);
			if (result == null)
				return NotFound(id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}

		[HttpPut]
		public IActionResult Put(Game game)
		{
			var result = _context.UpdateGame(game);
			if (result == null)
				return NotFound(game.Id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}

		[HttpPost]
		public IActionResult Post(Game game)
		{
			var result = _context.Add(game);

			if (result == null)
				return StatusCode(500, "Game already exists");


			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request");

			return Ok();
		}
	}
}

