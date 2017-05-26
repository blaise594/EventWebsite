using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpcomingEvents.Models;
using UpcomingEvents.ViewModels;
using System.Data.Entity;
namespace UpcomingEvents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var events = new ApplicationDbContext().Events.Include(i => i.Venue).Include(i => i.Genre).OrderBy(o => o.starttime).ToList();

            var vm = new HomePageViewModel();
            vm.Events = events;
            vm.ShoppingCart = Session["shoppingCart"] as OrderModel ?? new OrderModel();
            return View(vm);
        }
     
              

         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}