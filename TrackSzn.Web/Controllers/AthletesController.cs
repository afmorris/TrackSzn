using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
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
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId && !x.IsDeleted);

            var vm = new IndexViewModel {Athletes = athletes};

            return View(vm);
        }

        [Route("create")]
        public ActionResult Create()
        {
            var vm = new CreateViewModel();
            return View(vm);
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Name == viewModel.Name && x.GraduationYear == viewModel.GraduationYear && !x.IsDeleted);
            if (existing == null)
            {
                var athlete = Mapper.Map<Athlete>(viewModel);
                athlete.UserId = userId;
                Db.Insert(athlete);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Cannot add an athlete with the same name to your database.");
            return View(viewModel);
        }

        [Route("bulk")]
        public ActionResult BulkCreate()
        {
            var vm = new BulkCreateViewModel();
            vm.CreateViewModels.Add(new CreateViewModel());
            return View(vm);
        }

        [Route("bulk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkCreate(BulkCreateViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;

            foreach (var createViewModel in viewModel.CreateViewModels)
            {
                if (!string.IsNullOrEmpty(createViewModel.Name))
                {
                    var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Name == createViewModel.Name && x.GraduationYear == createViewModel.GraduationYear && !x.IsDeleted);
                    if (existing == null)
                    {
                        var athlete = Mapper.Map<Athlete>(createViewModel);
                        athlete.UserId = userId;
                        Db.Insert(athlete);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Route("edit/{id:int}")]
        public ActionResult EditExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var vm = new EditViewModel {Athlete = existing};
            return View(vm);
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Id == viewModel.Athlete.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            viewModel.Athlete.UserId = userId;
            Db.Update(viewModel.Athlete);
            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id:int}")]
        public ActionResult DeleteExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var athletePerformances = Db.LoadSelect<AthletePerformance>(x => x.UserId == userId && x.AthleteId == id && !x.IsDeleted).OrderBy(x => x.Event.Name).ThenBy(x => x.Meet.Date).ToList();
            var athleteLifts = Db.LoadSelect<AthleteLift>(x => x.UserId == userId && x.AthleteId == id && !x.IsDeleted).OrderBy(x => x.Lift.Id).ThenBy(x => x.SetNumber).ThenBy(x => x.Date).ToList();
            var vm = new DeleteViewModel {Athlete = existing, AthletePerformances = athletePerformances, AthleteLifts = athleteLifts};

            return View(vm);
        }

        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Athlete>(x => x.UserId == userId && x.Id == viewModel.Athlete.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            Db.UpdateOnly(() => new Athlete { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.Id == viewModel.Athlete.Id && x.UserId == userId && !x.IsDeleted);
            Db.UpdateOnly(() => new AthletePerformance { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.AthleteId == viewModel.Athlete.Id && x.UserId == userId && !x.IsDeleted);
            Db.UpdateOnly(() => new AthleteLift { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.AthleteId == viewModel.Athlete.Id && x.UserId == userId && !x.IsDeleted);
            return RedirectToAction(nameof(Index));
        }

        [Route("lifts")]
        public ActionResult AthleteLifts()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId);

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new LiftsViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("lifts/athletes/{id:int}")]
        public ActionResult AthleteLiftList(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athlete = Db.Single<Athlete>(x => x.Id == id && x.UserId == userId);
            athlete.AthleteLifts = Db.LoadSelect<AthleteLift>(x => x.AthleteId == id && x.UserId == userId);

            var liftsByDay = athlete.AthleteLifts.OrderBy(x => x.LiftId).ThenBy(x => x.SetNumber).GroupBy(x => x.Date);
            var vm = new AthleteLiftsViewModel(athlete, liftsByDay);

            return View(vm);
        }

        [Route("performances")]
        public ActionResult AthletePerformances()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athletes = Db.Select<Athlete>(x => x.UserId == userId);

            var athletesByGraduationYear = athletes.OrderBy(x => x.Name).GroupBy(x => x.GraduationYear).OrderByDescending(x => x.Key);
            var vm = new PerformancesViewModel(athletesByGraduationYear);

            return View(vm);
        }

        [Route("performances/athlete/{id:int}")]
        public ActionResult AthletePerformanceList(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var athlete = Db.Single<Athlete>(x => x.Id == id && x.UserId == userId);
            athlete.AthletePerformances = Db.LoadSelect<AthletePerformance>(x => x.AthleteId == id && x.UserId == userId);

            var performancesByEvent = athlete.AthletePerformances.OrderByDescending(x => x.Meet.Date).GroupBy(x => x.Event);
            var vm = new AthletePerformancesViewModel(athlete, performancesByEvent);

            return View(vm);
        }
    }
}