using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Movie")]
    public class MovieController : AbstractControllerBase
    {
        [OutputCache(CacheProfile = "Medium")]
        public ViewResult Index()
		{
			ViewData.Model = db.Movies.OrderBy(x => x.Title).ToList();
			return View();
		}

        //[OutputCache(CacheProfile = "Medium")]
        public ViewResult Genres()
		{
			ViewData.Model = db.Genres.OrderBy(x => x.Name).ToList();
			return View();
		}

        [OutputCache(CacheProfile = "MediumP")]
        [Route("Genre/{genrename}")]
		public ViewResult MoviesByGenre(string genrename)
		{
			ViewData.Model = db.Movies.Where(x => x.Genre.Name == genrename).OrderBy(x => x.Title).ToList();
            return View("Index");
		}

        //[OutputCache(CacheProfile = "MediumP")]
        public ActionResult Details(string id)
		{
			var movie = db.Movies.Find(id);
	
			ViewData.Model = movie;

			if(Request.IsAjaxRequest())
			{
				return PartialView();
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> postRating(int rating, string movieId)
		{
			if(rating > 0 && rating <= 5)
			{
				var movie = db.Movies.Find(movieId);

				if(movie != null)
				{
					movie.Ratings.Add(new MovieDAL.Rating()
					{
						Movie = movie,
						Vote = rating
					});

					await db.SaveChangesAsync();

					return Json("Tank you for voting");
				}
			}
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}

	}
}