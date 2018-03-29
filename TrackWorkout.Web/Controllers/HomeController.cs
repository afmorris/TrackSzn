using System.Web.Mvc;
using ServiceStack.Mvc;

namespace TrackWorkout.Web.Controllers
{
    [RoutePrefix("")]
    public class HomeController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}