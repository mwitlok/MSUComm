using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class ImageController : Controller
	{

		[Route("Image/{format}/{id}.jpg")]
		public ActionResult CreateImage(string format, string id)
		{
			if (format.ToLower() == "thumb")
			{
				new WebImage(Server.MapPath("~/App_Data/cover/" + id + ".jpg"))
					.Resize(100, 100)
					.AddTextWatermark("Communicate", "White", 8, "Bold")
					.Write();
			}
			else if (format.ToLower() == "medium")
			{
				new WebImage(Server.MapPath("~/App_Data/cover/" + id + ".jpg"))
					.Resize(300, 300)
					.AddTextWatermark("Ingars Movie Database", "White", 10, "Bold")
					.Write();
			}
			else return HttpNotFound();

			return new EmptyResult();
		}
	}
}