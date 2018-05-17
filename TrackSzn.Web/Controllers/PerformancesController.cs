using System;
using System.Linq;
using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackSzn.Models;
using TrackSzn.ViewModels.Performances;

namespace TrackSzn.Web.Controllers
{
    [RoutePrefix("performances")]
    public class PerformancesController : ServiceStackController
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
            athlete.AthletePerformances = Db.LoadSelect<AthletePerformance>(x => x.AthleteId == id);

            var performancesByEvent = athlete.AthletePerformances.OrderByDescending(x => x.Meet.Date).GroupBy(x => x.Event);
            var vm = new AthleteViewModel(athlete, performancesByEvent);

            return this.View(vm);
        }
    }
}