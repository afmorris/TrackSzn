using System;
using System.Linq;
using System.Web.Mvc;
using ServiceStack.MiniProfiler;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackWorkout.Models;
using TrackWorkout.ViewModels.Lifts;

namespace TrackWorkout.Web.Controllers
{
    [RoutePrefix("lifts")]
    public class LiftsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            var athletes = Db.Select<Athlete>().OrderBy(x => x.Name).ToList();
            var vm = new IndexViewModel(athletes);

            return View(vm);
        }

        [Route("athletes/{id:int}")]
        public ActionResult Athlete(int id)
        {
            var athlete = Db.LoadSingleById<Athlete>(id);
            athlete.AthleteLifts = Db.LoadSelect<AthleteLift>(x => x.AthleteId == id);
            var vm = new AthleteViewModel(athlete);

            return this.View(vm);
        }
    }
}