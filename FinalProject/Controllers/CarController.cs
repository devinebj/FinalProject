using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FinalProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CarController : ControllerBase
	{
		private readonly ILogger<CarController> _logger;
		private readonly ICarContextDAO _context;

		public CarController(ILogger<CarController> logger, ICarContextDAO context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllCars()
		{
			return Ok(_context.GetAllCars());
		}
	
		[HttpGet("id")]
		public IActionResult GetCarById(int id)
		{
			if(id == null || id == 0)
			{
				return Ok(_context.GetAllCars().Take(5));
			}

			var car = _context.GetCarById(id);
			if (car == null)
				return NotFound(id);

			return Ok(car);
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var result = _context.RemoveCarById(id);
			if (result == null)
				return NotFound(id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}

		[HttpPut]
		public IActionResult Put(Car car)
		{
			var result = _context.UpdateCar(car);
			if (result == null)
				return NotFound(car.Id);

			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request.");

			return Ok();
		}

		[HttpPost]
		public IActionResult Post(Car car)
		{
			var result = _context.Add(car);

			if (result == null)
				return StatusCode(500, "Car already exists");


			if (result == 0)
				return StatusCode(500, "An error occurred while processing your request");

			return Ok();
		}
	}
}
