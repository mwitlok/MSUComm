using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lmdb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name:  "Movies By Genre",
				url: "Movie/Genre/{genreName}", 
				defaults: new { controller = "Movie", action = "MoviesByGenre" });

			routes.MapRoute(
				name: "Person By Id",
				url: "Person/{id}",
				defaults: new { controller = "Person", action = "Details" },
				constraints: new { id=@"\d+"}
				);

			routes.MapRoute(
				name: "Image By Format",
				url: "Image/{format}/{id}.jpg",
				defaults: new { controller = "Image", action = "CreateImage" });

			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
