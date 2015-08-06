using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lmdb.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public String Actors()
        {
            return "PersonController.Actors()";
        }

		public String Producers()
		{
			return "PersonController.Producers()";
		}

		public String Directors()
		{
			return "PersonController.Directors()";
		}
		public String Details(int id)
		{
			return "PersonController.Details(" + id + ")";
		}
	}
}