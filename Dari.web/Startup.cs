using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dari.web.Startup))]
namespace Dari.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
