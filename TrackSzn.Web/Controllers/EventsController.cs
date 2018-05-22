using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using ServiceStack;
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
        [System.Web.Mvc.Route("")]
        public ActionResult Index()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var events = Db.Select<Event>(x => x.UserId == userId);

            var vm = new IndexViewModel(events);

            return View(vm);
        }

        [System.Web.Mvc.Route("create")]
        public ActionResult Create()
        {
            var vm = new CreateViewModel();
            return View(vm);
        }

        [System.Web.Mvc.Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Name == viewModel.Name);
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

        [System.Web.Mvc.Route("bulk-create")]
        public ActionResult BulkCreate()
        {
            var vm = new BulkCreateViewModel();
            vm.CreateViewModels.Add(new CreateViewModel());
            return View(vm);
        }

        [System.Web.Mvc.Route("bulk-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkCreate(BulkCreateViewModel viewModel)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;

            foreach (var createViewModel in viewModel.CreateViewModels)
            {
                if (!createViewModel.Name.IsNullOrEmpty())
                {
                    var existing = Db.Single<Event>(x => x.UserId == userId && x.Name == createViewModel.Name);
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

        [System.Web.Mvc.Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var vm = new EditViewModel();

            return View(vm);
        }

        [System.Web.Mvc.Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        [System.Web.Mvc.Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var vm = new DeleteViewModel();

            return View(vm);
        }

        [System.Web.Mvc.Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}