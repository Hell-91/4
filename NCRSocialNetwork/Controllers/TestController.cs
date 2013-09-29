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
    public class TestController : Controller
    {
        private NCRSocialNetworkDBEntities db = new NCRSocialNetworkDBEntities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var eventcomments = db.EventComments.Include(e => e.Event).Include(e => e.User).ToList();
            var comments = new List<EventComment>();

            /*foreach(var comment in eventcomments) {
                if (comment.Event.Club.ClubName == "Sports") {
                    comments.Add(comment);
                }
                 
            }*/
            return View(eventcomments);
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            EventComment eventcomment = db.EventComments.Find(id);
            if (eventcomment == null)
            {
                return HttpNotFound();
            }
            return View(eventcomment);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName");
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventComment eventcomment)
        {
            if (ModelState.IsValid)
            {
                db.EventComments.Add(eventcomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventcomment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventcomment.UserId);
            return View(eventcomment);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventComment eventcomment = db.EventComments.Find(id);
            if (eventcomment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventcomment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventcomment.UserId);
            return View(eventcomment);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventComment eventcomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventcomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventcomment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventcomment.UserId);
            return View(eventcomment);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventComment eventcomment = db.EventComments.Find(id);
            if (eventcomment == null)
            {
                return HttpNotFound();
            }
            return View(eventcomment);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventComment eventcomment = db.EventComments.Find(id);
            db.EventComments.Remove(eventcomment);
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