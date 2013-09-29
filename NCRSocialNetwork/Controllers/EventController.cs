using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRSocialNetwork.Models;

namespace NCRSocialNetwork.Controllers
{
    public class EventController : Controller
    {
        private NCRSocialNetworkDBEntities db = new NCRSocialNetworkDBEntities();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Club);
            return View(events.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Event Event = db.Events.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }
            return View(Event);
        }

        //
        // GET: /Event/Create

        public ActionResult NewEvent()
        {
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName");
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewEvent(Event Event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(Event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", Event.ClubId);
            return View(Event);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event Event = db.Events.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", Event.ClubId);
            return View(Event);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event Event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", Event.ClubId);
            return View(Event);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event Event = db.Events.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }
            return View(Event);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event Event = db.Events.Find(id);
            db.Events.Remove(Event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}