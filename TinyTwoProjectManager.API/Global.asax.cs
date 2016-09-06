using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using TinyTwoProjectManager.Data.Infrastructure;

namespace TinyTwoProjectManager.API
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyInjectorConfig.RegisterDependencies();
            MappingConfig.RegisterMappings();
            Database.SetInitializer(new ProjectManagerInitializer());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex != null)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "OPTIONS")
            {
                Response.StatusCode = 200;
                Response.End();
            }
        }
    }
}