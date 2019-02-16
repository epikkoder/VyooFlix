using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyooFlix.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Genre Genre { get; set; }

		public byte GenreId { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
	}
}