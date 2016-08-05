using System.Web.Optimization;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // If these aren't explicitly listed, they won't be loaded in the right order.
            bundles.Add(new ScriptBundle("~/ScriptBundles/ThirdParty")
                .Include("~/Scripts/ThirdParty/jquery-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-ui-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-validate-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-modal.min.js")
                .Include("~/Scripts/ThirdParty/bootstrap.min.js")
            );

            bundles.Add(new ScriptBundle("~/ScriptBundles/Site")
                .Include("~/Scripts/*.js")
            );

            bundles.Add(new StyleBundle("~/StyleBundles/ThirdParty")
                .Include("~/Content/Styles/ThirdParty/*.min.css")
            );

            bundles.Add(new StyleBundle("~/StyleBundles/Site")
                .Include("~/Content/Styles/*.css")
            );

            BundleTable.EnableOptimizations = true;
        }
    }
}