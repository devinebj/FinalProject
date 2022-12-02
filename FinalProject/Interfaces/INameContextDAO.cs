using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.Interfaces
{
	public interface INameContextDAO
	{
		List<Name> GetAllNames();
		Name GetNameById(int id);
		int? RemoveNameById(int id);
		int? UpdateName(Name name);
		int? Add(Name name);
	}
}
