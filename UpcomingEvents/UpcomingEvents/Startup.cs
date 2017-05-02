using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UpcomingEvents.Startup))]
namespace UpcomingEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
