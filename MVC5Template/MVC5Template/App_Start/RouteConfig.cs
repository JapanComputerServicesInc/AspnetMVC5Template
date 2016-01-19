using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Microsoft.AspNet.FriendlyUrls;

namespace MVC5Template
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
