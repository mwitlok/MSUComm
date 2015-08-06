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
    public class ImdbApiController : Controller
    {
		MovieDAL.ImdbContext db = new MovieDAL.ImdbContext();

		protected override void Dispose(bool disposable)
		{
			if (disposable) db.Dispose();
			base.Dispose(disposable);
		}

		// GET: ImdbApi
		public ActionResult Movies()
        {	
			var movies = db.Movies.OrderBy(x => x.Title).Select( x => new { id = x.MovieId, title = x.Title}).ToList();

			XDocument document = new XDocument
			(

			  new XDeclaration("1.0", "utf-8", "yes"),
			  new XElement("Movies",

				  from m in movies
				  select new XElement("Movie", new XAttribute("ID", m.id),
				  new XElement("Title", m.title)))
			);

			return Content(document.ToString(), "application/xml");
        }

		[Route("Movie/Details/{id}.xml")]
		public ActionResult Details(string id)
		{
			var movies = db.Movies.Find(id);

			XDocument document = new XDocument
			(

			new XDeclaration("1.0", "utf-8", "yes"),
				  new XElement("Movie", new XAttribute("ID", id),
				  new XElement("Title", movies.Title),
				  new XElement("OriginalTitle", movies.OriginalTitle),
				  new XElement("ProductionYear", movies.ProductionYear),
				  new XElement("RunningLength", movies.RunningLength))
            );

			return Content(document.ToString(), "application/xml");
		}
    }
}