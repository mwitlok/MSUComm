using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImdbWeb.Areas.Admin.Models.MovieModels;
using MovieDAL;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
    public class MovieController : Controller
    {
		const int MINUTES_IN_HOUR = 60;
		ImdbContext db = new MovieDAL.ImdbContext();

		protected override void Dispose(bool disposable)
		{
			if (disposable) db.Dispose();
			base.Dispose(disposable);
		}

		// GET: Admin/Movie
		//[OutputCache(CacheProfile = "Medium")]
		public ActionResult Index()
        {
			ViewData.Model = db.Movies.OrderBy(x => x.Title).ToList();
            return View();
        }

        public ActionResult Create()
        {

			var g = db.Genres.OrderBy(x => x.Name).ToList();
			ViewBag.genreList = new SelectList(g, "GenreId", "Name");

            return View(new MovieViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movie)
        {
            if(!ModelState.IsValid)
            {
				return View(movie);
            }

			Movie inserted = db.Movies.Add(new Movie()
			{
				MovieId = movie.id,
				Description = movie.desc,
				Genre = db.Genres.Find(movie.GenreId),
				OriginalTitle = movie.origTitlte,
				ProductionYear = movie.prodYear,
				RunningLength = (movie.runHour * MINUTES_IN_HOUR) +  movie.runMin,
				Title = movie.title
			});

			if (inserted == null) return View(movie); //TODO dont fuck up; 

			db.SaveChanges();

			return RedirectToAction("Index");
        }

		[HttpPost]
		public JsonResult checkIdRemote(string id)
		{
			var db = new MovieDAL.ImdbContext();
			if (db.Movies.Any(x => x.MovieId == id))
			{
				return Json("Movie is already registered");
			}

			return Json(true);
		}
	}
}