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
    public class LikeDislikeController : Controller
    {
        private NCRSocialNetworkDBEntities db = new NCRSocialNetworkDBEntities();

        //
        // GET: /LikeDislike/

        public ActionResult Index()
        {
            var eventlikedislikes = db.EventLikeDislikes.Include(e => e.Event).Include(e => e.User);
            return View(eventlikedislikes.ToList());

        }

        //
        // GET: /LikeDislike/Details/5

        public ActionResult Details(int id = 0)
        {
            EventLikeDislike eventlikedislike = db.EventLikeDislikes.Find(id);
            if (eventlikedislike == null)
            {
                return HttpNotFound();
            }
            return View(eventlikedislike);
        }

        //
        // GET: /LikeDislike/Create

        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName");
            return View();
        }

        //
        // POST: /LikeDislike/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventLikeDislike eventlikedislike)
        {
            if (ModelState.IsValid)
            {
                db.EventLikeDislikes.Add(eventlikedislike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventlikedislike.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventlikedislike.UserId);
            return View(eventlikedislike);
        }

        //
        // GET: /LikeDislike/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventLikeDislike eventlikedislike = db.EventLikeDislikes.Find(id);
            if (eventlikedislike == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventlikedislike.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventlikedislike.UserId);
            return View(eventlikedislike);
        }

        //
        // POST: /LikeDislike/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventLikeDislike eventlikedislike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventlikedislike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventlikedislike.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserFirstName", eventlikedislike.UserId);
            return View(eventlikedislike);
        }

        //
        // GET: /LikeDislike/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventLikeDislike eventlikedislike = db.EventLikeDislikes.Find(id);
            if (eventlikedislike == null)
            {
                return HttpNotFound();
            }
            return View(eventlikedislike);
        }

        //
        // POST: /LikeDislike/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventLikeDislike eventlikedislike = db.EventLikeDislikes.Find(id);
            db.EventLikeDislikes.Remove(eventlikedislike);
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