using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebContacts.Startup))]
namespace WebContacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
