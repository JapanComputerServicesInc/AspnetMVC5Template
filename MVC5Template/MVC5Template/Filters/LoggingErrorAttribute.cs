using NLog;
using System;
using System.Web.Mvc;

namespace MVC5Template.Filters
{
    public class LoggingErrorAttribute : FilterAttribute, IExceptionFilter
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            // ルートパラメーターを取得
            var route = filterContext.RouteData;
            // アクションメソッドで発生した例外情報を取得
            var exp = filterContext.Exception;

            var err = new ErrorLog
            {
                Controller = route.Values["controller"].ToString(),
                Action = route.Values["action"].ToString(),
                LogMessageGenerator = exp.Message,
                Stacktrace = exp.StackTrace,
                Updated = DateTime.Now
            };
        }
    }
}