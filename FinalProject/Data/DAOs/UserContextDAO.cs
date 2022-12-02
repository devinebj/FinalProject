using FinalProject.Models;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
	public class UserContextDAO : IUserContextDAO
	{
		private UserContext _context;

		public UserContextDAO(UserContext context)
		{
			_context = context;
		}

		public List<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public int? RemoveUserById(int id)
		{
			var user = GetUserById(id);
			if (user == null) return null;
			try
			{
				_context.Users.Remove(user);
				_context.SaveChanges();
				return 1;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public int? UpdateUser(User user)
		{
			var userToUpdate = GetUserById(user.Id);
			if (userToUpdate == null)
				return null;

			userToUpdate.Id = user.Id;
			userToUpdate.UserName = user.UserName;
			userToUpdate.Password = user.Password;
			userToUpdate.Email = user.Email;
			userToUpdate.DateJoined = user.DateJoined;

			try
			{
				_context.Users.Update(userToUpdate);
				_context.SaveChanges();
				return 1;
			} 
			catch (Exception)
			{
				return 0;
			}
		}

		public int? Add(User user)
		{
			var users = _context.Users.Where(x => x.UserName.Equals(user.UserName)).FirstOrDefault();

			if (users != null)
				return null;

			try
			{
				_context.Users.Add(user);
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
