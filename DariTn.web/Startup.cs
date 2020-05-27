using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DariTn.web.Startup))]
namespace DariTn.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
