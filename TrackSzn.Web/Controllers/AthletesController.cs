using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackSzn.Models;
using TrackSzn.ViewModels.Athletes;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("athletes")]
    public class AthletesController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("lifts")]
        public ActionResult Lifts()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId);

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new LiftsViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("lifts/athletes/{id:int}")]
        public ActionResult AthleteLifts(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athlete = Db.Single<Athlete>(x => x.Id == id && x.UserId == userId);
            athlete.AthleteLifts = Db.LoadSelect<AthleteLift>(x => x.AthleteId == id && x.UserId == userId);

            var liftsByDay = athlete.AthleteLifts.OrderBy(x => x.LiftId).ThenBy(x => x.SetNumber).GroupBy(x => x.Date);
            var vm = new AthleteLiftsViewModel(athlete, liftsByDay);

            return this.View(vm);
        }

        [Route("performances")]
        public ActionResult Performances()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId);

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new PerformancesViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("performances/athlete/{id:int}")]
        public ActionResult AthletePerformances(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athlete = Db.Single<Athlete>(x => x.Id == id && x.UserId == userId);
            athlete.AthletePerformances = Db.LoadSelect<AthletePerformance>(x => x.AthleteId == id && x.UserId == userId);

            var performancesByEvent = athlete.AthletePerformances.OrderByDescending(x => x.Meet.Date).GroupBy(x => x.Event);
            var vm = new AthletePerformancesViewModel(athlete, performancesByEvent);

            return this.View(vm);
        }
    }
}