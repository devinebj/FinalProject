using FinalProject.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
	public class GameContextDAO : IGameContextDAO
	{
		private GameContext _context;

		public GameContextDAO(GameContext context)
		{
			_context = context;
		}

		public List<Game> GetAllGames()
		{
			return _context.Games.ToList();
		}

		public Game GetGameById(int id)
		{
			return _context.Games.Where(x => x.Id.Equals(id)).FirstOrDefault();
		}

		public int? RemoveGameById(int id)
		{
			var name = GetGameById(id);
			if (name == null) return null;
			try
			{
				_context.Games.Remove(name);
				_context.SaveChanges();
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
				_context.Games.Update(gameToUpdate);
				_context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}

		public int? Add(Game game)
		{
			var games = _context.Games.Where(x => x.Title.Equals(game.Title)).FirstOrDefault();

			if (games != null)
				return null;

			try
			{
				_context.Games.Add(game);
				_context.SaveChanges();
				return 1;
			} catch (Exception)
			{
				return 0;
			}
		}
	}
}
