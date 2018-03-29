using System;
using System.Linq;
using System.Web.Mvc;
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

        [Route("athletes/{id:guid}")]
        public ActionResult Athlete(Guid id)
        {
            var athlete = Db.SingleById<Athlete>(id);
            var athleteLifts = Db.Select<AthleteLift>(x => x.AthleteId == id);
            foreach (var athleteLift in athleteLifts)
            {
                athleteLift.Athlete = athlete;
                athleteLift.Lift = Db.SingleById<Lift>(athleteLift.LiftId);
            }

            var vm = new AthleteViewModel(athlete, athleteLifts);

            return this.View(vm);
        }
    }
}