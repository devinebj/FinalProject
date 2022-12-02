using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.Interfaces
{
	public interface IGameContextDAO
	{
		List<Game> GetAllGames();
		Game GetGameById(int id);
		int? RemoveGameById(int id);
		int? UpdateGame(Game game);
		int? Add(Game game);
	}
}
