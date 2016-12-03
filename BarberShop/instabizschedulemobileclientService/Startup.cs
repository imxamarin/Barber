using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(instabizschedulemobileclientService.Startup))]

namespace instabizschedulemobileclientService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}