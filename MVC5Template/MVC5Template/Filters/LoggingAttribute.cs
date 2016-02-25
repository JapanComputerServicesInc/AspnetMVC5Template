using NLog;
using System.Text;
using System.Web.Mvc;

namespace MVC5Template.Filters
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Logging(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Logging(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            Logging(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Logging(filterContext);
        }

        private void Logging(ControllerContext filterContext)
        {
            StringBuilder logText = new StringBuilder();
            var route = filterContext.RouteData;
            var values = route.Values;
            foreach (var key in values.Keys)
            {
                logText.Append(key);
                logText.Append(" = ");
                logText.Append(values[key]);
                logText.Append(",");
            }
            logger.Info(logText.ToString());
        }
    }
}