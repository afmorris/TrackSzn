using System.Linq;
using System.Security.Claims;
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
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId);

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new IndexViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("athletes/{id:int}")]
        public ActionResult Athlete(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athlete = Db.Single<Athlete>(x => x.Id == id && x.UserId == userId);
            athlete.AthleteLifts = Db.LoadSelect<AthleteLift>(x => x.AthleteId == id && x.UserId == userId);

            var liftsByDay = athlete.AthleteLifts.OrderBy(x => x.LiftId).ThenBy(x => x.SetNumber).GroupBy(x => x.Date);
            var vm = new AthleteViewModel(athlete, liftsByDay);

            return this.View(vm);
        }
    }
}