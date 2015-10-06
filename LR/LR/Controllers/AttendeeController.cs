using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LR.Models;

namespace LR.Controllers
{
    public class AttendeeController : Controller
    {
        private Db db = new Db();

        // POST: Attendee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Mealtime")] AttendeeModel attendeeModel)
        {
            if (ModelState.IsValid)
            {
                attendeeModel.Id = Guid.NewGuid();
                db.Attendees.Add(attendeeModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(attendeeModel);
        }

        // POST: Attendee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AttendeeModel attendeeModel = db.Attendees.Find(id);
            db.Attendees.Remove(attendeeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
