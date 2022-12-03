using FinalProject.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
	public class GameContextDAO : IGameContextDAO
	{
		private GameContext context;

		public GameContextDAO(GameContext context)
		{
			this.context = context;
		}

		public List<Game> GetAllGames()
		{
			return context.Games.ToList();
		}

		public Game GetGameById(int id)
		{
			return context.Games.Where(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public int? RemoveGameById(int id)
		{
			var game = GetGameById(id);
			if (game == null) return null;
			try
			{
				context.Games.Remove(game);
				context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}

		public int? UpdateGame(Game game)
		{
			var gameToUpdate = GetGameById(game.Id);
			if (gameToUpdate == null)
				return null;

			gameToUpdate.Id = game.Id;
			gameToUpdate.Title = game.Title;
			gameToUpdate.ReleaseDate = game.ReleaseDate;
			gameToUpdate.Rating = game.Rating;
			gameToUpdate.Developer = game.Developer;

			try
			{
				context.Games.Update(gameToUpdate);
				context.SaveChanges();
				return 1;
			} 
			catch (Exception)
			{
				return 0;
			}
		}

		public int? Add(Game game)
		{
			var _game = context.Games.Where(x => x.Title.Equals(game.Title)).FirstOrDefault();

			if (_game != null)
				return null;

			try
			{
				context.Games.Add(_game);
				context.SaveChanges();
				return 1;
			} 
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
