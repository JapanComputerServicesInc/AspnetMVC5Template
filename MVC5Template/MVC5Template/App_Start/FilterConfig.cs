using System.Web;
using System.Web.Mvc;

namespace MVC5Template
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // デフォで認証が必要
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
