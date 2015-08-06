using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImdbWeb.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Login(string usr, string pwd)
        {
			string user = "communicate";
			string pass = "pwd";
			if (user == usr && pass == pwd)
			{
				FormsAuthentication.SetAuthCookie(usr, false);
				return RedirectToAction("Index", "Movie");
			}
			return View();
        }

		[Authorize]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home", new { area=""});
		}
	}
}