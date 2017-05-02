using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UpcomingEvents.Models
{
    public class EventModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }

        // foreign key annnotations and virtual properties
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public VenueModel Venue { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public GenreModel Genre { get; set; }
    }
}