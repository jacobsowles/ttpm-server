using System.Web.Optimization;

namespace TinyTwoProjectManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(new ScriptBundle("~/Scripts/Home/ThirdParty").Include(
                "~/Scripts/ThirdParty/jquery-{version}.js",
                "~/Scripts/ThirdParty/jquery.validate*",
                "~/Scripts/ThirdParty/modernizr-*",
                "~/Scripts/ThirdParty/bootstrap.js",
                "~/Scripts/ThirdParty/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Home/Site"));

            bundles.Add(new ScriptBundle("~/Scripts/Dashboard/ThirdParty").Include(
                "~/Scripts/ThirdParty/jquery-3.1.0.min.js",
                "~/Scripts/ThirdParty/jquery-ui-1.12.0.min.js",
                "~/Scripts/ThirdParty/jquery-validate.min.js",
                "~/Scripts/ThirdParty/jquery-modal.min.js",
                "~/Scripts/ThirdParty/bootstrap.min.js",
                "~/Scripts/ThirdParty/jquery-circle-progress.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Dashboard/Site").Include(
                "~/Scripts/*.js"
            ));

            // Styles
            bundles.Add(new StyleBundle("~/Styles/Home/ThirdParty").Include(
                "~/Content/Styles/ThirdParty/bootstrap.css"
            ));

            bundles.Add(new StyleBundle("~/Styles/Home/Site").Include(
                "~/Content/Styles/global.css",
                "~/Content/Styles/home-layout.css"
            ));

            bundles.Add(new StyleBundle("~/Styles/Dashboard/ThirdParty").Include(
                "~/Content/Styles/ThirdParty/*.css"
            ));

            bundles.Add(new StyleBundle("~/Styles/Dashboard/Site").Include(
                "~/Content/Styles/global.css",
                "~/Content/Styles/dashboard-layout.css",
                "~/Content/Styles/modal.css",
                "~/Content/Styles/module.css",
                "~/Content/Styles/task.css",
                "~/Content/Styles/status-box.css"
            ));
        }
    }
}