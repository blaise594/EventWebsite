namespace UpcomingEvents.Migrations
{
    using System;
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

            var ownerEmail = "boss@gmail.com";
            var defaultPassword = "Password1!";
            if (!context.Users.Any(u => u.UserName == ownerEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = ownerEmail };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, boss);
            }

            // Add a first account
        }
    }
}
