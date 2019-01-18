using System.Web;
using System.Web.Optimization;

namespace testDataBase
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/javaScript/layui.js",
                        "~/Content/javaScript/layui.all.js",
                        "~/Content/javaScript/jquery-2.1.0.js"
                        ));
            
        
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/stylesheet/layui.css",
                      "~/Content/stylesheet/StyleSheet.css",
                      "~/Content/stylesheet/layui.mobile.css"
                      ));
        }
    }
}
