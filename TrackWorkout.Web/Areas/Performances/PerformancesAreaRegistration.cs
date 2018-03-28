using System.Web.Mvc;
using TrackWorkout.Web.Areas.Performances.Controllers;

namespace TrackWorkout.Web.Areas.Performances
{
    public class PerformancesAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Performances";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Performances_default",
                "Performances/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new [] { typeof(HomeController).Namespace }
            );
        }
    }
}