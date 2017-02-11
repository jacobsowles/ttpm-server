using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TinyTwoProjectManager.API.Startup))]

namespace TinyTwoProjectManager.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}