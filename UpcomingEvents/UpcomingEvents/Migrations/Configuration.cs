namespace UpcomingEvents.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using UpcomingEvents.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UpcomingEvents.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UpcomingEvents.Models.ApplicationDbContext context)
        {
            //Add roles
            var boss = "owner";
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == boss))
            {
                var role = new IdentityRole { Name = boss };
                manager.Create(role);
            }

            var ownerEmail = "danielbrogers594@gmail.com";
            var defaultPassword = "Password1!";
            if (!context.Users.Any(u => u.UserName == ownerEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = ownerEmail };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, boss);
            }

            
            var concert = new GenreModel { type = "Concert" };

           
            context.Genres.AddOrUpdate(g => g.type, concert);

            var venue = new VenueModel { name = "Janus" };
            context.Venues.AddOrUpdate(v => v.name, venue);
            context.SaveChanges();

            var es = new List<EventModel>
            {
                new EventModel{title ="Band A", VenueId = venue.id, GenreId = concert.id, starttime = DateTime.Now},


                new EventModel{title ="Band B", VenueId = venue.id, GenreId = concert.id,starttime = DateTime.Now},


                new EventModel{title ="Band C", VenueId = venue.id, GenreId = concert.id,starttime = DateTime.Now},
                new EventModel{title ="Band D", VenueId = venue.id, GenreId = concert.id, starttime = DateTime.Now},
            };

            var os = new OrderModel { UserId = "552831a0-bef9-4b2b-a6ec-5fc90182530f" };
            context.Orders.AddOrUpdate(o => o.Id, os);
            context.SaveChanges();

            for (int i = 0; i < 20; i++)
            {
                var ticket = new TicketModel
                {
                    EventId = 3,
                    OrderId = 2
                };

                context.Tickets.AddOrUpdate(t => t.Id, ticket);
                context.SaveChanges();

            }

            for (int i = 0; i < 20; i++)
            {
                var ticket = new TicketModel
                {
                    EventId = 4,
                    OrderId = 2
                };

                context.Tickets.AddOrUpdate(t => t.Id, ticket);
                context.SaveChanges();

            }

            for (int i = 0; i < 20; i++)
            {
                var ticket = new TicketModel
                {
                    EventId = 5,
                    OrderId = 2
                };

                context.Tickets.AddOrUpdate(t => t.Id, ticket);
                context.SaveChanges();

            }

            for (int i = 0; i < 20; i++)
            {
                var ticket = new TicketModel
                {
                    EventId = 6,
                    OrderId = 2
                };

                context.Tickets.AddOrUpdate(t => t.Id, ticket);
                context.SaveChanges();

            }

            for (int i = 0; i < 20; i++)
            {
                var ticket = new TicketModel
                {
                    EventId = 7,
                    OrderId = 2
                };

                context.Tickets.AddOrUpdate(t => t.Id, ticket);
                context.SaveChanges();

            }




            es.ForEach(eve => context.Events.AddOrUpdate(e => e.title, eve));
            context.SaveChanges();
        }
    }
}
