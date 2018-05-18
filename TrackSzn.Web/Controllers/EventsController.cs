using System.Security.Claims;
using System.Web.Mvc;
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
    }
}