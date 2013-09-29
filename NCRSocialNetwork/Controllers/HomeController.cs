using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRSocialNetwork.ViewModels;
using NCRSocialNetwork.Models;
using System.Data;
using System.Data.Entity;

namespace NCRSocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private NCRSocialNetworkDBEntities dbConn = new NCRSocialNetworkDBEntities();

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel() { 
                Club = dbConn.Clubs.ToList(),
                Event = dbConn.Events.Include(e => e.Club).ToList(),
                Comments = dbConn.EventComments.Include(e => e.Event).Include(e => e.User).ToList(),
                EventLikeDislike = dbConn.EventLikeDislikes.Include(e => e.Event).Include(e => e.User).ToList()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public PartialViewResult SubmitComment(int UserId, string UserName, string UserComment, int EventId)
        {
            var eventcomment = new EventComment() { 
                UserId = UserId,
                EventCommentDescription = UserComment,
                EventId = EventId
            };            
            if (ModelState.IsValid)
            {
                dbConn.EventComments.Add(eventcomment);
                dbConn.SaveChanges();
            }
            ViewBag.Comment = UserName + ": " + UserComment;
            return PartialView("_EventCommentView");
        }

        [HttpPost]
        public PartialViewResult LikeEvent(int UserId, int EventId)
        {
            var eventlike = new EventLikeDislike(){
                UserId = UserId,
                EventId = EventId,
                EventLike = 1
            };
            if (ModelState.IsValid)
            {
                dbConn.EventLikeDislikes.Add(eventlike);
                dbConn.SaveChanges();
            }
            ViewBag.Likes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 1);
            ViewBag.Dislikes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 0);
            return PartialView("_LikeDislikeView");
        }

        [HttpPost]
        public PartialViewResult DislikeEvent(int UserId, int EventId)
        {
            var eventlike = new EventLikeDislike()
            {
                UserId = UserId,
                EventId = EventId,
                EventLike = 0
            };
            if (ModelState.IsValid)
            {
                dbConn.EventLikeDislikes.Add(eventlike);
                dbConn.SaveChanges();
            }
            ViewBag.Likes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 1);
            ViewBag.Dislikes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 0);
            return PartialView("_LikeDislikeView");
        }

        [HttpPost]
        public PartialViewResult UnlikeEvent(int UserId, int EventId)
        {
            var eventLikeDislike = dbConn.EventLikeDislikes.Where(e => e.EventId == EventId && e.UserId == UserId).FirstOrDefault();
            EventLikeDislike eventlikedislike = dbConn.EventLikeDislikes.Find(eventLikeDislike.EventLikeDislikeId);
            dbConn.EventLikeDislikes.Remove(eventlikedislike);
            dbConn.SaveChanges();

            ViewBag.Likes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 1);
            ViewBag.Dislikes = dbConn.EventLikeDislikes.Count(e => e.EventId == EventId && e.EventLike == 0);
            return PartialView("_LikeDislikeView");
        }
    }
}
