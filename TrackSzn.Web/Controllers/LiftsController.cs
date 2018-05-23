using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
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
            var lifts = Db.Select<Lift>(x => x.UserId == userId && !x.IsDeleted);

            var vm = new IndexViewModel {Lifts = lifts};

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
            var existing = Db.Single<Lift>(x => x.UserId == userId && x.Name == viewModel.Name && !x.IsDeleted);
            if (existing == null)
            {
                var lift = Mapper.Map<Lift>(viewModel);
                lift.UserId = userId;
                Db.Insert(lift);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Cannot add a lift with the same name to your database.");
            return View(viewModel);
        }

        [Route("bulk-create")]
        public ActionResult BulkCreate()
        {
            var vm = new BulkCreateViewModel();
            vm.CreateViewModels.Add(new CreateViewModel());
            return View(vm);
        }

        [Route("bulk-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkCreate(BulkCreateViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;

            foreach (var createViewModel in viewModel.CreateViewModels)
            {
                if (!string.IsNullOrEmpty(createViewModel.Name))
                {
                    var existing = Db.Single<Lift>(x => x.UserId == userId && x.Name == createViewModel.Name && !x.IsDeleted);
                    if (existing == null)
                    {
                        var lift = Mapper.Map<Lift>(createViewModel);
                        lift.UserId = userId;
                        Db.Insert(lift);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Route("edit/{id:int}")]
        public ActionResult EditExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Lift>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var vm = new EditViewModel {Lift = existing};
            return View(vm);
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Lift>(x => x.UserId == userId && x.Id == viewModel.Lift.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            viewModel.Lift.UserId = userId;
            Db.Update(viewModel.Lift);
            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id:int}")]
        public ActionResult DeleteExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Lift>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var athleteLifts = Db.LoadSelect<AthleteLift>(x => x.UserId == userId && x.LiftId == id && !x.IsDeleted).OrderBy(x => x.Athlete.Name).ThenBy(x => x.Date).ThenBy(x => x.SetNumber).ToList();
            var vm = new DeleteViewModel {Lift = existing, AthleteLifts = athleteLifts};

            return View(vm);
        }

        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Lift>(x => x.UserId == userId && x.Id == viewModel.Lift.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            Db.UpdateOnly(() => new Lift { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.Id == viewModel.Lift.Id && x.UserId == userId && !x.IsDeleted);
            Db.UpdateOnly(() => new AthleteLift { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.LiftId == viewModel.Lift.Id && x.UserId == userId && !x.IsDeleted);
            return RedirectToAction(nameof(Index));
        }
    }
}