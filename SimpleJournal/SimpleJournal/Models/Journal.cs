using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleJournal.Models
{
    public class Journal
    {
        
        public int JournalId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }

        public virtual List<Subscription> Subscribers { get; set; }
        public List<Post> Posts { get; set; }
    }
}
