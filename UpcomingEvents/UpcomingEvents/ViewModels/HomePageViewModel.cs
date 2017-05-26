using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpcomingEvents.Models;

namespace UpcomingEvents.ViewModels
{
    public class HomePageViewModel
    {
       
            public IEnumerable<EventModel> Events { get; set; }
            public OrderModel ShoppingCart { get; set; }
        
    }
}
