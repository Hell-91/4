using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCRSocialNetwork.Models;

namespace NCRSocialNetwork.ViewModels
{
    public class FestivalsViewModel
    {
        public Club Club { get; set; }

        public List<Event> Events { get; set; }

        public List<EventComment> Comments { get; set; }

        public List<EventLikeDislike> EventLikeDislikes { get; set; }
    }
}