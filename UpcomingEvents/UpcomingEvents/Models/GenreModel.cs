using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpcomingEvents.Models
{
    public class GenreModel
    {
        public int id { get; set; }
        public string type { get; set; }

        public ICollection<EventModel> Events { get; set; } = new HashSet<EventModel>();
    }
}