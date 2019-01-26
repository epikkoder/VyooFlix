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

	    public ActionResult New()
	    {
		    var genres = _context.Genres.ToList();

		    var viewModel = new MovieFormViewModel
		    {
			    Genres = genres
		    };

		    ViewBag.Title = "New Movie";

		    return View("MovieForm", viewModel);
	    }
	}
}