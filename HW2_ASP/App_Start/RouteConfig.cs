using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW2_ASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "Login",
                defaults: new { controller = "Login", action = "Login" }
            );
            routes.MapRoute(
                name: "Registrate",
                url: "Registrate",
                defaults: new { controller = "Registrate", action = "Registrate" }
            );
            routes.MapRoute(
                name: "General",
                url: "General",
                defaults: new { controller = "General", action = "General" }
            );
            routes.MapRoute(
                name: "Admins",
                url: "Admins",
                defaults: new { controller = "Admins", action = "Admins" }
            );
            routes.MapRoute(
                name: "AddMusic",
                url: "AddMusic",
                defaults: new { controller = "AddMusic", action = "AddMusic" }
            );
        }
    }
}
