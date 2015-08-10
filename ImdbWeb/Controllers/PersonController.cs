using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class PersonController : AbstractControllerBase
    {
        [OutputCache(CacheProfile = "Medium")]
        public ViewResult Actors()
		{
			var sDB = db.Persons.Where(x => x.ActedMovies.Any()).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Actors";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}

        [OutputCache(CacheProfile = "Medium")]
        public ViewResult Producers()
		{
			var sDB = db.Persons.Where(x => x.ProducedMovies.Count > 0).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Producers";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}

        [OutputCache(CacheProfile = "Medium")]
        public ViewResult Directors()
		{
			var sDB = db.Persons.Where(x => x.DirectedMovies.Count > 0).OrderBy(x => x.Name).ToList();
			dynamic mymodel = new ExpandoObject();
			mymodel.Title = "Directors";
			mymodel.Persons = sDB;

			return View("Person", mymodel);
		}

        //[OutputCache(CacheProfile = "MediumP")]
        [Route("Person/{id:int}")]
		public ViewResult Details(int id)
		{
			var sDB = db.Persons.Where(x => x.PersonId == id).FirstOrDefault();
			ViewData.Model = sDB;

			return View();
		}

	}
}