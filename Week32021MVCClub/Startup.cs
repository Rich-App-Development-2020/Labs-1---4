using ActivityTracker;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week32021MVCClub.Startup))]
namespace Week32021MVCClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Activity.Track("Starting up MVC app");
            ConfigureAuth(app);
        }
    }
}
