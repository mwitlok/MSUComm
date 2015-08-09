using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class HomeController : Controller
    {
        //[OutputCache(CacheProfile = "Medium")]
        public ViewResult Index()
		{
			return View();
		}
    }
}