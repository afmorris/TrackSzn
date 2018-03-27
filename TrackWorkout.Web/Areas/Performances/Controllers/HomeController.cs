using System.Web.Mvc;

namespace TrackWorkout.Web.Areas.Performances.Controllers
{
    public class HomeController : Controller
    {
        // GET: Performances/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}