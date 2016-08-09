using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TinyTwoProjectManager.Web.Startup))]
namespace TinyTwoProjectManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
