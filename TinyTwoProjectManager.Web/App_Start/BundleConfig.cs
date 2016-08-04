using System.Web.Optimization;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/ScriptBundles/ThirdParty")
                .Include("~/Scripts/ThirdParty/jquery-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-ui-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-validate-{version}.min.js")
                .Include("~/Scripts/ThirdParty/jquery-modal.min.js")
                .Include("~/Scripts/ThirdParty/bootstrap.min.js")
            );

            bundles.Add(new ScriptBundle("~/ScriptBundles/Site")
                .Include("~/Scripts/accordion.js")
                .Include("~/Scripts/projects.js")
            );

            bundles.Add(new StyleBundle("~/StyleBundles/ThirdParty")
                .Include("~/Content/Styles/ThirdParty/bootstrap.min.css")
                .Include("~/Content/Styles/ThirdParty/bootstrap-theme.min.css")
                .Include("~/Content/Styles/ThirdParty/jquery-modal.min.css")
            );

            bundles.Add(new StyleBundle("~/StyleBundles/Site")
                .Include("~/Content/Styles/global.css")
                .Include("~/Content/Styles/structure.css")
                .Include("~/Content/Styles/modules.css")
                .Include("~/Content/Styles/accordion.css")
                .Include("~/Content/Styles/modal.css")
                .Include("~/Content/Styles/project-list.css")
            );

            BundleTable.EnableOptimizations = true;
        }
    }
}