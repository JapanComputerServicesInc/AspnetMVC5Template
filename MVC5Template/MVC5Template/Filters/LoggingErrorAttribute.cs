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
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            // ルートパラメーターを取得
            var route = filterContext.RouteData;
            // アクションメソッドで発生した例外情報を取得
            var exp = filterContext.Exception;

            string controller = route.Values["controller"].ToString();
            string action = route.Values["action"].ToString();

            var err = new ErrorLog
            {
                Controller = controller,
                Action = action,
                LogMessageGenerator = exp.Message,
                Stacktrace = exp.StackTrace,
                Updated = DateTime.Now
            };
            logger.Error(filterContext.Exception, "{0}|{1}|{2}|{3}", controller, action, exp.Message, exp.StackTrace);
        }
    }
}