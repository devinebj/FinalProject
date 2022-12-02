using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.Interfaces
{
	public interface ICarContextDAO
	{
		List<Car> GetAllCars();
		Car GetCarById(int id);
		int? RemoveCarById(int id);
		int? UpdateCar(Car car);
		int? Add(Car car);
	}
}
