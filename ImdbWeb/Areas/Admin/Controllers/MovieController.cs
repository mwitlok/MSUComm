﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
    public class MovieController : Controller
    {
        // GET: Admin/Movie
        public ActionResult Index()
        {
			return View();
        }
    }
}