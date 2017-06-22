using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleJournal.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime CreateDate { get; set; }

        public String Follower { get; set; }
        public Journal Journal { get; set; }
    }
}
