using LR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LR.Controllers
{
    public class HomeController : Controller
    {
        Db db = new Db(); 

        public ActionResult Index()
        {
            ViewBag.Attendees = db.Attendees.ToList();

            return View();
        }
    }
}