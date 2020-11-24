using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fleet_Tracker.Startup))]
namespace Fleet_Tracker
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
