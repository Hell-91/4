using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCRSocialNetwork.Models;

namespace NCRSocialNetwork.ViewModels
{
    public class AdminViewModel
    {
        public List<Club> Club { get; set; }

        public List<Event> Event { get; set; }

        public List<EventLikeDislike> EventLikeDislike { get; set; }

        public List<ClubEvent> ClubEvent { get; set; }
    }
}