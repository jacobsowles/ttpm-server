using TinyTwoProjectManager.Web.Attributes;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class FilterConfig
    {
        public static void Configure(System.Web.Mvc.GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}