using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpcomingEvents.Models
{
    public class VenueModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public ICollection<EventModel> Events { get; set; } = new HashSet<EventModel>();
    }
}