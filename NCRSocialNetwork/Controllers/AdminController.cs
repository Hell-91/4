using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRSocialNetwork.Models;
using NCRSocialNetwork.ViewModels;

namespace NCRSocialNetwork.Controllers
{
    public class AdminController : Controller
    {
        private NCRSocialNetworkDBEntities db = new NCRSocialNetworkDBEntities();

        //
        // GET: /Admin/
        private NCRSocialNetworkDBEntities dbConn = new NCRSocialNetworkDBEntities();

        public ActionResult Index()
        {
           
            var viewModel = new AdminViewModel()
            {
                Club = dbConn.Clubs.ToList(),
                Event = dbConn.Events.Include(e => e.Club).ToList(),
                ClubEvent = dbConn.ClubEvents.Include(c => c.Club).Include(c => c.Event).ToList(),
                EventLikeDislike = dbConn.EventLikeDislikes.Include(e => e.Event).Include(e => e.User).ToList()
            };

            return View(viewModel);
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            ClubEvent clubevent = db.ClubEvents.Find(id);
            if (clubevent == null)
            {
                return HttpNotFound();
            }
            return View(clubevent);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName");
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle");
            return View();
        }

        //
        // POST: /Admin/Create

        public ActionResult AddClub(int EventId, int ClubId)
        {
            var clubevent = new ClubEvent()
            {
                EventId = EventId,
                ClubId = ClubId
            };
            if (ModelState.IsValid)
            {
                db.ClubEvents.Add(clubevent);
                db.SaveChanges();                
            }
            return View();
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClubEvent clubevent = db.ClubEvents.Find(id);
            if (clubevent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", clubevent.ClubId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", clubevent.EventId);
            return View(clubevent);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClubEvent clubevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.Clubs, "ClubId", "ClubName", clubevent.ClubId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", clubevent.EventId);
            return View(clubevent);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClubEvent clubevent = db.ClubEvents.Find(id);
            if (clubevent == null)
            {
                return HttpNotFound();
            }
            return View(clubevent);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubEvent clubevent = db.ClubEvents.Find(id);
            db.ClubEvents.Remove(clubevent);
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