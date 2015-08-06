using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class PersonController : Controller
    {
		public ViewResult Actors()
		{
			var db = new MovieDAL.ImdbContext();
			var sDB = db.Persons.Where(x => x.ActedMovies.Any()).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Actors";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}
		public ViewResult Producers()
		{
			var db = new MovieDAL.ImdbContext();
			var sDB = db.Persons.Where(x => x.ProducedMovies.Count > 0).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Producers";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}
		public ViewResult Directors()
		{
			var db = new MovieDAL.ImdbContext();
			var sDB = db.Persons.Where(x => x.DirectedMovies.Count > 0).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Directors";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}

		[Route("Person/{id:int}")]
		public ViewResult Details(int id)
		{
			var db = new MovieDAL.ImdbContext();

			var sDB = db.Persons.Where(x => x.PersonId == id).FirstOrDefault();

			ViewData.Model = sDB;

			return View();
		}

	}
}