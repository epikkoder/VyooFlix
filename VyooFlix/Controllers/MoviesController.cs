using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyooFlix.Models;
using VyooFlix.ViewModels;

namespace VyooFlix.Controllers
{
    public class MoviesController : Controller
    {
	    List<Movie> movies = new List<Movie>
	    {
		    new Movie {Id = 1, Name = "Shrek"},
		    new Movie {Id = 2, Name = "Wall-E"}
	    };

		// GET: Movies/Index
		public ActionResult Index()
        {
			return View(movies);
		}

		//[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
		//   public ActionResult ByReleaseDate(int year, int month)
		//   {
		//    return Content(year + "/" + month);
		//   }

	    public ActionResult Details(int id)
	    {
		    Movie movie = null;
		    foreach (Movie m in movies)
		    {
			    if (m.Id == id)
				    movie = m;
		    }

		    if (movie == null)
			    return HttpNotFound();

		    return View(movie);
	    }
	}
}