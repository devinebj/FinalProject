using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class NameController : ControllerBase
	{
		private readonly ILogger<NameController> _logger;
		private readonly INameContextDAO _context;

		public NameController(ILogger<NameController> logger, INameContextDAO context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllNames()
		{
			return Ok(_context.GetAllNames());
		}

		[HttpGet("id")]
		public IActionResult GetNameById(int id)
		{
			var name = _context.GetNameById(id);
			if (name == null)
				return NotFound(id);

			return Ok(name);
		}
		
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var result = _context.RemoveNameById(id);
			if (result == null)
				return NotFound(id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");
			
			return Ok();
		}

		[HttpPut]
		public IActionResult Put(Name name)
		{
			var result = _context.UpdateName(name);
			if (result == null)
				return NotFound(name.Id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}

		[HttpPost]
		public IActionResult Post(Name name)
		{
			var result = _context.Add(name);

			if (result == null)
				return StatusCode(500, "Name already exists");
				

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request");

			return Ok();
		}
	}
}
