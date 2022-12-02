using FinalProject.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
	public class CarContextDAO : ICarContextDAO
	{
		private CarContext _context;

		public CarContextDAO(CarContext context)
		{
			_context = context;
		}

		public List<Car> GetAllCars()
		{
			return _context.Cars.ToList();
		}

		public Car GetCarById(int id)
		{
			return _context.Cars.Where(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public int? RemoveCarById(int id)
		{
			var name = GetCarById(id);
			if (name == null) return null;
			try
			{
				_context.Cars.Remove(name);
				_context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}

		public int? UpdateCar(Car car)
		{
			var carToUpdate = GetCarById(car.Id);
			if (carToUpdate == null)
				return null;

			carToUpdate.Id = car.Id;
			carToUpdate.Make = car.Make;
			carToUpdate.Model = car.Model;
			carToUpdate.Year = car.Year;
			carToUpdate.Color = car.Color;

			try
			{
				_context.Cars.Update(carToUpdate);
				_context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}

		public int? Add(Car car)
		{
			var cars = _context.Cars.Where(x => x.Make.Equals(car.Make) &&
				x.Model.Equals(car.Model) &&
				x.Year.Equals(car.Year) &&
				x.Color.Equals(car.Color)
			).FirstOrDefault();

			if (cars != null)
				return null;

			try
			{
				_context.Cars.Add(car);
				_context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}
	}
}
