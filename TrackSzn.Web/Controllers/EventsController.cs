using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackSzn.Models;
using TrackSzn.ViewModels.Events;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("events")]
    public class EventsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var events = Db.Select<Event>(x => x.UserId == userId && !x.IsDeleted);

            var vm = new IndexViewModel {Events = events};

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
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Name == viewModel.Name && !x.IsDeleted);
            if (existing == null)
            {
                var ev = Mapper.Map<Event>(viewModel);
                ev.UserId = userId;
                Db.Insert(ev);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Cannot add an event with the same name to your database.");
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
                    var existing = Db.Single<Event>(x => x.UserId == userId && x.Name == createViewModel.Name && !x.IsDeleted);
                    if (existing == null)
                    {
                        var ev = Mapper.Map<Event>(createViewModel);
                        ev.UserId = userId;
                        Db.Insert(ev);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Route("edit/{id:int}")]
        public ActionResult EditExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var vm = new EditViewModel {Event = existing};
            return View(vm);
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Id == viewModel.Event.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            viewModel.Event.UserId = userId;
            Db.Update(viewModel.Event);
            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id:int}")]
        public ActionResult DeleteExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var athletePerformances = Db.LoadSelect<AthletePerformance>(x => x.UserId == userId && x.EventId == id && !x.IsDeleted).OrderBy(x => x.Athlete.Name).ThenBy(x => x.Meet.Date).ToList();
            var vm = new DeleteViewModel {Event = existing, AthletePerformances = athletePerformances};

            return View(vm);
        }

        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Id == viewModel.Event.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            Db.UpdateOnly(() => new Event { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.Id == viewModel.Event.Id && x.UserId == userId && !x.IsDeleted);
            Db.UpdateOnly(() => new AthletePerformance { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.EventId == viewModel.Event.Id && x.UserId == userId && !x.IsDeleted);
            return RedirectToAction(nameof(Index));
        }
    }
}