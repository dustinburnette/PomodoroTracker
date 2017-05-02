using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PomodoroTracker.Startup))]
namespace PomodoroTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
