using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JXDevPlanner.WebMVC.Startup))]
namespace JXDevPlanner.WebMVC
{
    class ConsoleSystem {

    }

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
