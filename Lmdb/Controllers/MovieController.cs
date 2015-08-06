using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lmdb.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public String Index()
        {
            return "MovieController.Index()";
        }

		public String Details(int id)
		{
			return $"MovieController.Details({id})";
		}

		public String Genres()
		{
			return "MovieController.Genres()";
		}
		public String MoviesByGenre(String genreName)
		{
			return "MovieController.MoviesByGenre(" + genreName + ")";
		}
	}
}