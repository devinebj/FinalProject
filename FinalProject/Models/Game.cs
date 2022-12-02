﻿using System;

namespace FinalProject.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Rating { get; set; }
		public string Developer { get; set; }
	}
}
