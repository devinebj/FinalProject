using FinalProject.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
	public class NameContextDAO : INameContextDAO
	{
		private NameContext _context;
		
		public NameContextDAO(NameContext context)
		{
			_context = context;
		}

		public List<Name> GetAllNames()
		{
			return _context.Names.ToList();
		}

		public Name GetNameById(int id)
		{
			return _context.Names.Where(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public int? RemoveNameById(int id)
		{
			var name = GetNameById(id);
			if (name == null) return null;
			try
			{
				_context.Names.Remove(name);
				_context.SaveChanges();
				return 1;
			} 
			catch (Exception) {
				return 0;
			}
		}

		public int? UpdateName(Name name)
		{
			var nameToUpdate = GetNameById(name.Id);
			if (nameToUpdate == null)
				return null;

			nameToUpdate.Id = name.Id;
			nameToUpdate.name = name.name;
			nameToUpdate.birthdate = name.birthdate;
			nameToUpdate.collegeProgram = name.collegeProgram;
			nameToUpdate.yearInProgram = name.yearInProgram;
			
			try {
				_context.Names.Update(nameToUpdate);
				_context.SaveChanges();
				return 1;
			}
			catch(Exception)
			{
				return 0;
			}
		}

		public int? Add(Name name)
		{
			var names = _context.Names.Where(x => x.name.Equals(name.name)).FirstOrDefault();

			if (names != null)
				return null;

			try
			{
				_context.Names.Add(name);
				_context.SaveChanges();
				return 1;
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
