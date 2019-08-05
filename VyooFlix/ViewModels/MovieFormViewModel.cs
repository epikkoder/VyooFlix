﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VyooFlix.Models;

namespace VyooFlix.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

		public int? Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte? GenreId { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required, Range(1, 20)]
		[Display(Name = "Number in Stock")]
		public byte? NumInStock { get; set; }

		public string Title
		{
			get
			{
				return Id != 0 ? "Edit Movie" : "New Movie";
			}
		}

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			NumInStock = movie.NumInStock;
			GenreId = movie.GenreId;
		}
	}
}