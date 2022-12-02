using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.Interfaces
{
	public interface IUserContextDAO
	{
		List<User> GetAllUsers();
		User GetUserById(int id);
		int? RemoveUserById(int id);
		int? UpdateUser(User user);
		int? Add(User user);
	}
}
