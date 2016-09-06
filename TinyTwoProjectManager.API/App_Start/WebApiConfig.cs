using System.Web.Http;

namespace TinyTwoProjectManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));    Enabled in Web.config insteadB
        }
    }
}