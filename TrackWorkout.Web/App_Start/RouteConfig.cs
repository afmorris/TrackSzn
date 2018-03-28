using System.Web.Mvc;
using System.Web.Routing;
using TrackWorkout.Web.Controllers;

namespace TrackWorkout.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new [] { typeof(HomeController).Namespace }
            );
        }
    }
}
