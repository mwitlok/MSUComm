using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lmdb.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public string CreateImage(string format, int id)
        {
			var x = id;
			return " ImageController.CreateImage(" + format + "," + x + ")";

        }
    }
}