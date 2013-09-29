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
    public class ClubsController : Controller
    {
        //
        // GET: /Clubs/
        private NCRSocialNetworkDBEntities dbConn = new NCRSocialNetworkDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sports() 
        {
            var validEvents = dbConn.ClubEvents.ToList().Where(e => e.Club.ClubName == "Sports");
            var Events = dbConn.Events.ToList().Where(e => e.Club.ClubName == "Sports" );
            var Comments = dbConn.EventComments.ToList().Where(e => e.Event.Club.ClubName == "Sports");
            var EventLikesDislikes = dbConn.EventLikeDislikes.ToList().Where(e => e.Event.Club.ClubName == "Sports");

            var events = new List<Event>();
            foreach (var e in Events) {
                foreach (var v in validEvents) {
                    if (v.EventId == e.EventId) {
                        events.Add(e);
                        break;
                    }
                }
            }

            var comments = new List<EventComment>();
            foreach (var c in Comments) {
                foreach (var v in validEvents)
                {
                    if (v.EventId == c.EventId)
                    {
                        comments.Add(c);
                        break;
                    }
                }
            }

            var eventlikesdislikes = new List<EventLikeDislike>();
            foreach (var e in EventLikesDislikes)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        eventlikesdislikes.Add(e);
                        break;
                    }
                }
            }

            SportsViewModel viewModel = new SportsViewModel() { 
                Events = events,
                Comments = comments,
                Club = dbConn.Clubs.Where(c => c.ClubName == "Sports").Single(),
                EventLikeDislikes = eventlikesdislikes
            };
            return View(viewModel);
        }

        public ActionResult Music()
        {
            var validEvents = dbConn.ClubEvents.ToList().Where(e => e.Club.ClubName == "Sports");
            var Events = dbConn.Events.ToList().Where(e => e.Club.ClubName == "Music");
            var Comments = dbConn.EventComments.ToList().Where(e => e.Event.Club.ClubName == "Music");
            var EventLikesDislikes = dbConn.EventLikeDislikes.ToList().Where(e => e.Event.Club.ClubName == "Music");

            var events = new List<Event>();
            foreach (var e in Events)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        events.Add(e);
                        break;
                    }
                }
            }

            var comments = new List<EventComment>();
            foreach (var c in Comments)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == c.EventId)
                    {
                        comments.Add(c);
                        break;
                    }
                }
            }

            var eventlikesdislikes = new List<EventLikeDislike>();
            foreach (var e in EventLikesDislikes)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        eventlikesdislikes.Add(e);
                        break;
                    }
                }
            }

            MusicViewModel viewModel = new MusicViewModel()
            {
                Events = events,
                Comments = comments,
                Club = dbConn.Clubs.Where(c => c.ClubName == "Music").Single(),
                EventLikeDislikes = eventlikesdislikes
            };
            return View(viewModel);
        }

        public ActionResult Dance()
        {
            var validEvents = dbConn.ClubEvents.ToList().Where(e => e.Club.ClubName == "Dance");
            var Events = dbConn.Events.ToList().Where(e => e.Club.ClubName == "Dance");
            var Comments = dbConn.EventComments.ToList().Where(e => e.Event.Club.ClubName == "Dance");
            var EventLikesDislikes = dbConn.EventLikeDislikes.ToList().Where(e => e.Event.Club.ClubName == "Dance");

            var events = new List<Event>();
            foreach (var e in Events)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        events.Add(e);
                        break;
                    }
                }
            }

            var comments = new List<EventComment>();
            foreach (var c in Comments)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == c.EventId)
                    {
                        comments.Add(c);
                        break;
                    }
                }
            }

            var eventlikesdislikes = new List<EventLikeDislike>();
            foreach (var e in EventLikesDislikes)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        eventlikesdislikes.Add(e);
                        break;
                    }
                }
            }

            DanceViewModel viewModel = new DanceViewModel()
            {
                Events = events,
                Comments = comments,
                Club = dbConn.Clubs.Where(c => c.ClubName == "Dance").Single(),
                EventLikeDislikes = eventlikesdislikes
            };
            return View(viewModel); 
        }

        public ActionResult Festivals()
        {
            var validEvents = dbConn.ClubEvents.ToList().Where(e => e.Club.ClubName == "Festivals");
            var Events = dbConn.Events.ToList().Where(e => e.Club.ClubName == "Festivals");
            var Comments = dbConn.EventComments.ToList().Where(e => e.Event.Club.ClubName == "Festivals");
            var EventLikesDislikes = dbConn.EventLikeDislikes.ToList().Where(e => e.Event.Club.ClubName == "Festivals");

            var events = new List<Event>();
            foreach (var e in Events)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        events.Add(e);
                        break;
                    }
                }
            }

            var comments = new List<EventComment>();
            foreach (var c in Comments)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == c.EventId)
                    {
                        comments.Add(c);
                        break;
                    }
                }
            }

            var eventlikesdislikes = new List<EventLikeDislike>();
            foreach (var e in EventLikesDislikes)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        eventlikesdislikes.Add(e);
                        break;
                    }
                }
            }

            FestivalsViewModel viewModel = new FestivalsViewModel()
            {
                Events = events,
                Comments = comments,
                Club = dbConn.Clubs.Where(c => c.ClubName == "Festivals").Single(),
                EventLikeDislikes = eventlikesdislikes
            };
            return View(viewModel);
        }

        public ActionResult Health()
        {
            var validEvents = dbConn.ClubEvents.ToList().Where(e => e.Club.ClubName == "Health");
            var Events = dbConn.Events.ToList().Where(e => e.Club.ClubName == "Health");
            var Comments = dbConn.EventComments.ToList().Where(e => e.Event.Club.ClubName == "Health");
            var EventLikesDislikes = dbConn.EventLikeDislikes.ToList().Where(e => e.Event.Club.ClubName == "Health");

            var events = new List<Event>();
            foreach (var e in Events)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        events.Add(e);
                        break;
                    }
                }
            }

            var comments = new List<EventComment>();
            foreach (var c in Comments)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == c.EventId)
                    {
                        comments.Add(c);
                        break;
                    }
                }
            }

            var eventlikesdislikes = new List<EventLikeDislike>();
            foreach (var e in EventLikesDislikes)
            {
                foreach (var v in validEvents)
                {
                    if (v.EventId == e.EventId)
                    {
                        eventlikesdislikes.Add(e);
                        break;
                    }
                }
            }

            HealthViewModel viewModel = new HealthViewModel()
            {
                Events = events,
                Comments = comments,
                Club = dbConn.Clubs.Where(c => c.ClubName == "Health").Single(),
                EventLikeDislikes = eventlikesdislikes
            };
            return View(viewModel);
        }

    }
}
