using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRegistrations.Startup))]
namespace WebRegistrations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
