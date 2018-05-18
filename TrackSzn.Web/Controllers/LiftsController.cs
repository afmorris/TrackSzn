using System.Linq;
using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackSzn.Models;
using TrackSzn.ViewModels.Lifts;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("lifts")]
    public class LiftsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            var athletes = Db.Select<Athlete>();

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new IndexViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("athletes/{id:int}")]
        public ActionResult Athlete(int id)
        {
            var athlete = Db.LoadSingleById<Athlete>(id);
            athlete.AthleteLifts = Db.LoadSelect<AthleteLift>(x => x.AthleteId == id);

            var liftsByDay = athlete.AthleteLifts.OrderBy(x => x.LiftId).ThenBy(x => x.SetNumber).GroupBy(x => x.Date);
            var vm = new AthleteViewModel(athlete, liftsByDay);

            return this.View(vm);
        }
    }
}