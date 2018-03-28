using System.Web.Mvc;

namespace TrackWorkout.Web.Areas.Performances.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}