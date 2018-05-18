using System.Web.Mvc;
using ServiceStack.Mvc;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("meets")]
    public class MeetsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("calendar")]
        public ActionResult Calendar()
        {
            return View();
        }
    }
}