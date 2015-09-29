using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var matcher = Worker.MatchingWorker.Instance;

            return View();
        }
    }
}