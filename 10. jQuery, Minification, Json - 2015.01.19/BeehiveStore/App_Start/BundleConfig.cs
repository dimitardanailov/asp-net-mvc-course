using System.Web;
using System.Web.Optimization;

namespace BeehiveStore.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, 
        // visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Enables CDN support
            bundles.UseCdn = true;

            // Enable minification 
            // NOTE: Breaks some JS functionality when set to 'true'
            // e.g. updating project data in 'Edit Project'
            BundleTable.EnableOptimizations = false;

            // jQuery library
            bundles.Add(new ScriptBundle("~/bundles/jquerylib").Include(
                        "~/Scripts/jQuery/jquery-2.1.3.js"));

            // Validations
            bundles.Add(new ScriptBundle("~/bundle/jqueryvalidations").Include(
               "~/Scripts/jQuery/libs/unobtrusive/jquery.unobtrusive-ajax.js",
               "~/Scripts/jQuery/libs/validate/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/external/modernizr/modernizr-*"));
        }
    }
}