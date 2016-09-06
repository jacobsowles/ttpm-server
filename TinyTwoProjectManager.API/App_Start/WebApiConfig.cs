using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TinyTwoProjectManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));    Enabled in Web.config insteadB
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}