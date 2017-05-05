using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UpcomingEvents.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();

        [DisplayFormat(DataFormatString = "{0:C}")]
        [NotMapped]
        public double TotalPrice
        {
            get
            {
                if (Tickets == null)
                {
                    return 0;
                }
                return Tickets.Sum(s => s.PurchasedPrice);
            }
        }

    }
}