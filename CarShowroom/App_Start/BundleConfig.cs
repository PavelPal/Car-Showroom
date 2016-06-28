using System.Web.Optimization;

namespace CarShowroom
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/mui").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/jquery.sticky.js",
                "~/Scripts/jquery.easing.1.3.min.js",
                "~/Scripts/main.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css"));
        }
    }
}