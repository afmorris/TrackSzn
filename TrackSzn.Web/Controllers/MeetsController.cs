using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using TrackSzn.Models;
using TrackSzn.ViewModels.Meets;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("meets")]
    public class MeetsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var meets = Db.Select<Meet>(x => x.UserId == userId && !x.IsDeleted);

            var vm = new IndexViewModel {Meets = meets};

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
            var existing = Db.Single<Meet>(x => x.UserId == userId && x.Name == viewModel.Name && x.Date == viewModel.Date && !x.IsDeleted);
            if (existing == null)
            {
                var meet = Mapper.Map<Meet>(viewModel);
                meet.UserId = userId;
                Db.Insert(meet);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Cannot add a meet with the same name to your database.");
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
                    var existing = Db.Single<Meet>(x => x.UserId == userId && x.Name == createViewModel.Name && x.Date == createViewModel.Date && !x.IsDeleted);
                    if (existing == null)
                    {
                        var meet = Mapper.Map<Meet>(createViewModel);
                        meet.UserId = userId;
                        Db.Insert(meet);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Route("edit/{id:int}")]
        public ActionResult EditExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Meet>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var vm = new EditViewModel {Meet = existing};
            return View(vm);
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Meet>(x => x.UserId == userId && x.Id == viewModel.Meet.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            viewModel.Meet.UserId = userId;
            Db.Update(viewModel.Meet);
            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id:int}")]
        public ActionResult DeleteExisting(int id)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Meet>(x => x.UserId == userId && x.Id == id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var athletePerformances = Db.LoadSelect<AthletePerformance>(x => x.UserId == userId && x.MeetId == id && !x.IsDeleted).OrderBy(x => x.Athlete.Name).ThenBy(x => x.Event.Name).ToList();
            var vm = new DeleteViewModel {Meet = existing, AthletePerformances = athletePerformances};

            return View(vm);
        }

        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Meet>(x => x.UserId == userId && x.Id == viewModel.Meet.Id && !x.IsDeleted);
            if (existing == null)
            {
                return HttpNotFound();
            }

            Db.UpdateOnly(() => new Meet { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.Id == viewModel.Meet.Id && x.UserId == userId && !x.IsDeleted);
            Db.UpdateOnly(() => new AthletePerformance { IsDeleted = true, DeletedDate = DateTime.Now }, where: x => x.MeetId == viewModel.Meet.Id && x.UserId == userId && !x.IsDeleted);
            return RedirectToAction(nameof(Index));
        }

        [Route("calendar")]
        public ActionResult Calendar()
        {
            return View();
        }
    }
}