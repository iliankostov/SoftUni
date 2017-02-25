using Microsoft.Owin;
using OnlineShop.Service;

[assembly: OwinStartup(typeof(Startup))]

namespace OnlineShop.Service
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