using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ImdbWeb.Controllers
{
	public class ImdbApiController : AbstractControllerBase
	{
		// GET: ImdbApi
        [OutputCache(CacheProfile = "MediumP")]
		public ActionResult Movies(string fmt)
		{
			var movies = db.Movies.OrderBy(x => x.Title).Select(x => new { id = x.MovieId, title = x.Title }).ToList();

			if (fmt == null || fmt.ToLower() != "json")
			{
				XDocument document = new XDocument
				(

					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("Movies",
						from m in movies
						select new XElement("Movie", new XAttribute("ID", m.id),
						new XElement("Title", m.title))
					)
				);

				return Content(document.ToString(), "application/xml");
			}
			else
			{
				return Json(movies, JsonRequestBehavior.AllowGet);
			}			
		}

        //[OutputCache(CacheProfile = "MediumP")]
        [Route("Movie/Details/{id}.xml")]
		public ActionResult Details(string id)
		{
			var movies = db.Movies.Find(id);

			if(movies != null)
			{
				XDocument document = new XDocument
				(
					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("movie",
						new XAttribute("id", id),
						new XElement("title", movies.Title),
						new XElement("originalTitle", movies.OriginalTitle),
						new XElement("productionYear", movies.ProductionYear),
						new XElement("runningLength", movies.RunningLength),
						new XElement("actors", 
							from p in movies.Actors select new XElement("name", p.Name)
						)
					)
				);
				return Content(document.ToString(), "application/xml");
			}
			return HttpNotFound($"No movie with id: {id} exists.");
		}
	}
}