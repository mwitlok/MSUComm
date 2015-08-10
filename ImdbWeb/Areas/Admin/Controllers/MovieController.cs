using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImdbWeb.Areas.Admin.Models.MovieModels;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
    public class MovieController : Controller
    {
        // GET: Admin/Movie
        //[OutputCache(CacheProfile = "Medium")]
        public ActionResult Index()
        {
            var db = new MovieDAL.ImdbContext();
            ViewData.Model = db.Movies.OrderBy(x => x.Title).Select(x =>
                                                                        new MovieViewModel()
                                                                        {
                                                                            movie = x
                                                                        }).ToList();
            return View();
        }

        public ActionResult Create()
        {
            ViewData.Model = new MovieCreateModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreateModel movie)
        {
            //TODO: Finish this method :O 
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Movie", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Movie", new { area = "Admin" });
        }
    }
}