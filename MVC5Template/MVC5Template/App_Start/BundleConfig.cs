using System.Web.Optimization;

namespace MVC5Template
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/html5shiv").Include(
                      "~/Scripts/html5shiv.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Render Handsontable
            bundles.Add(new ScriptBundle("~/bundles/handsontable").Include(
                        "~/Scripts/handsontable-master/dist/handsontable.full.js"));

            bundles.Add(new StyleBundle("~/Content/handsontable").Include(
                      "~/Scripts/handsontable-master/dist/handsontable.full.css",
                      "~/Scripts/handsontable-master/plugins/bootstrap/handsontable.bootstrap.css"));
        }
    }
}
