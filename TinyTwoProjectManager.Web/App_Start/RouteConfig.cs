using System.Web.Mvc;
using System.Web.Routing;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class RouteConfig
    {
        public static void Configure(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Project",
                url: "{controller}/{action}",
                defaults: new { controller = "Project", action = "Create" }
            );

            routes.MapRoute(
                name: "TaskList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TaskList", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}