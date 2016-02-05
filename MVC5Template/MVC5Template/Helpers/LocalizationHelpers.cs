using System.Globalization;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace MVC5Template.Helpers
{
    public static class LocalizationHelpers
    {
        // MvcHtmlString を返すように変更
        public static MvcHtmlString Resource(this HtmlHelper htmlhelper, string expression, params object[] args)
        {
            var virtualPath = GetVirtualPath(htmlhelper);

            return MvcHtmlString.Create(GetResourceString(htmlhelper.ViewContext.HttpContext, expression, virtualPath, args));
        }

        public static string Resource(this Controller controller, string expression, params object[] args)
        {
            return GetResourceString(controller.HttpContext, expression, "~/", args);
        }

        private static string GetResourceString(HttpContextBase httpContext, string expression, string virtualPath, object[] args)
        {
            var context = new ExpressionBuilderContext(virtualPath);
            var builder = new ResourceExpressionBuilder();
            var fields = (ResourceExpressionFields)builder.ParseExpression(expression, typeof(string), context);

            if (!string.IsNullOrEmpty(fields.ClassKey))
                return string.Format((string)httpContext.GetGlobalResourceObject(fields.ClassKey, fields.ResourceKey, CultureInfo.CurrentUICulture), args);

            return string.Format((string)httpContext.GetLocalResourceObject(virtualPath, fields.ResourceKey, CultureInfo.CurrentUICulture), args);
        }

        private static string GetVirtualPath(HtmlHelper htmlhelper)
        {
            // WebFormView 決め打ちではなくて基底クラスにキャストするように変更
            var view = htmlhelper.ViewContext.View as BuildManagerCompiledView;

            if (view != null)
                return view.ViewPath;

            return null;
        }
    }
}
