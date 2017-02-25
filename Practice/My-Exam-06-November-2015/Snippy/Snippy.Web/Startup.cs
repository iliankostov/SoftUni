using Microsoft.Owin;

[assembly: OwinStartup(typeof(Snippy.Web.Startup))]

namespace Snippy.Web
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