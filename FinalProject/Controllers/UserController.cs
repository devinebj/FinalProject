using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserContextDAO _context;

		public UserController(ILogger<UserController> logger, IUserContextDAO context)
		{
			_logger = logger;
			_context = context;
		}
	
		[HttpGet]
		public IActionResult GetAllUsers()
		{
			return Ok(_context.GetAllUsers());
		}

		[HttpGet("id")]
		public IActionResult GetUserById(int id)
		{
			var user = _context.GetUserById(id);
			if (user == null)
				return NotFound(id);

			return Ok(user);
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var result = _context.RemoveUserById(id);
			if (result == null)
				return NotFound(id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}
	
		[HttpPut]
		public IActionResult Put(User user)
		{
			var result = _context.UpdateUser(user);
			if (result == null)
				return NotFound(user.Id);

			if (result == 0)
				return StatusCode(500, "An error while processing your request.");

			return Ok();
		}

		[HttpPost]
		public IActionResult Post(User user)
		{
			var result = _context.Add(user);

			if (result == null)
				return StatusCode(500, "User already exists.");

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}
	}
}
