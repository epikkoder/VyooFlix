using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyooFlix.Models;
using VyooFlix.ViewModels;

namespace VyooFlix.Controllers
{
    public class MoviesController : Controller
    {
	    private ApplicationDbContext _context;

	    public MoviesController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
			_context.Dispose();
	    }

		// GET: Movies/Index
		public ActionResult Index()
		{
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
		}

		//[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
		//   public ActionResult ByReleaseDate(int year, int month)
		//   {
		//    return Content(year + "/" + month);
		//   }

	    //public ActionResult Details(int id)
	    //{
		   // Movie movie = null;
		   // foreach (Movie m in movies)
		   // {
			  //  if (m.Id == id)
				 //   movie = m;
		   // }

		   // if (movie == null)
			  //  return HttpNotFound();

		   // return View(movie);
	    //}
	}
}