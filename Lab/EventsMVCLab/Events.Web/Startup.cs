using Microsoft.Owin;

[assembly: OwinStartup(typeof(Events.Web.Startup))]

namespace Events.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}