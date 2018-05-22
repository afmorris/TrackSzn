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
            var events = Db.Select<Event>(x => x.UserId == userId);

            var vm = new IndexViewModel(events);

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
            var existing = Db.Single<Event>(x => x.UserId == userId && x.Name == viewModel.Name);
            if (existing == null)
            {
                var ev = Mapper.Map<Event>(viewModel);
                ev.UserId = userId;
                Db.Insert(ev);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Cannot add an event with the same name to your database.");
                return View(viewModel);
            }
        }

        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var vm = new EditViewModel();

            return View(vm);
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var vm = new DeleteViewModel();

            return View(vm);
        }

        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}