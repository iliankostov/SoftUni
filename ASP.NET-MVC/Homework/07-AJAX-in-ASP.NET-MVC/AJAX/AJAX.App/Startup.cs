using Microsoft.Owin;

[assembly: OwinStartup(typeof(AJAX.App.Startup))]

namespace AJAX.App
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