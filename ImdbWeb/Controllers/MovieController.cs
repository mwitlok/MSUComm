using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Movie")]
    public class MovieController : Controller
    {
		public ViewResult Index()
		{
			var db = new MovieDAL.ImdbContext();
			ViewData.Model = db.Movies.OrderBy(x => x.Title).ToList();

			return View();
		}

		public ViewResult Genres()
		{
			var db = new MovieDAL.ImdbContext();
			ViewData.Model = db.Genres.OrderBy(x => x.Name).ToList();

			return View();
		}

		[Route("Genre/{genrename}")]
		public ViewResult MoviesByGenre(string genrename)
		{
			var db = new MovieDAL.ImdbContext();
			ViewData.Model = db.Movies.Where(x => x.Genre.Name == genrename).OrderBy(x => x.Title).ToList();
            return View("Index");
		}

		public ViewResult Details(string id)
		{
			var db = new MovieDAL.ImdbContext();

			var movie = db.Movies.Find(id);
	
			ViewData.Model = movie;

			return View();
		}

	}
}