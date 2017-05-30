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

        [HttpPost]
        public ActionResult ShoppingCart(int id)
        {
            var cart = Session["cart"] as OrderModel;
            if (cart == null)
            {
                // create a new cart
                cart = new OrderModel()
                {
                    TimeCreated = DateTime.Now
                };
            }
            // too get the 
            var itemToAdd = new ApplicationDbContext().Tickets.FirstOrDefault(f => f.Id == id);            
           
            // add item select to shopping cart
            

            Session["cart"] = cart;
            return PartialView("_shoppingCart", cart);
        }

        [HttpDelete]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = Session["cart"] as OrderModel;
            cart.Tickets = cart.Tickets.Where(w => w.Id == id) as ICollection<TicketModel>;
            return PartialView("_checkoutDisplayCart", cart);
        }


        public ActionResult Checkout()
        {
            // Shopping Cart (order) as the model
            var vm = Session["cart"] as OrderModel;
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