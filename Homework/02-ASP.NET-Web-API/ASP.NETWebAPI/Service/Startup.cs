using Microsoft.Owin;

[assembly: OwinStartup(typeof(Service.Startup))]

namespace Service
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