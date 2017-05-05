using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace UpcomingEvents.Models
{
    public class EventModel
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }

        [DataType(DataType.Date)]
        public string description { get; set; }
        public DateTime? starttime { get; set; }
        public DateTime? endtime { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        // foreign key annnotations and virtual properties
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public VenueModel Venue { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public GenreModel Genre { get; set; }

        public ICollection<TicketModel> TicketsSold { get; set; } = new HashSet<TicketModel>();
    }
}