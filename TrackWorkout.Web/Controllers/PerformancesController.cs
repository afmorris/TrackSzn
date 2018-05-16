using System;
using System.Web.Mvc;
using ServiceStack.Mvc;

namespace TrackWorkout.Web.Controllers
{
    [RoutePrefix("performances")]
    public class PerformancesController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("athletes/{id:int}")]
        public ActionResult Athlete(int id)
        {
            return this.View(id);
        }
    }
}