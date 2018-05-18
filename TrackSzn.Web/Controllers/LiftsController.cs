﻿using System.Web.Mvc;
using ServiceStack.Mvc;

namespace TrackSzn.Web.Controllers
{
    [Authorize]
    [RoutePrefix("lifts")]
    public class LiftsController : ServiceStackController
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}