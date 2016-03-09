using NLog;
using System;
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
            Logging(System.Reflection.MethodBase.GetCurrentMethod().Name, filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Logging(System.Reflection.MethodBase.GetCurrentMethod().Name, filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            Logging(System.Reflection.MethodBase.GetCurrentMethod().Name, filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Logging(System.Reflection.MethodBase.GetCurrentMethod().Name, filterContext);
        }

        private void Logging(string method, ControllerContext filterContext)
        {
            StringBuilder logText = new StringBuilder();
            var route = filterContext.RouteData;
            var values = route.Values;

            logText.Append(string.Format("{0}|", method));
            foreach (var key in values.Keys)
            {
                logText.Append(string.Format("{0}={1}|", key, values[key]));
            }
            logger.Debug(logText.ToString());

            string timestamp = new DateTimeOffset(filterContext.HttpContext.Timestamp).ToString();
            string url = filterContext.HttpContext.Request.ServerVariables["URL"];
            string remoteAddr = filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
            string remoteUser = filterContext.HttpContext.Request.ServerVariables["REMOTE_USER"];
            string serverProtocol = filterContext.HttpContext.Request.ServerVariables["SERVER_PROTOCOL"];
            string httpUserAgent = filterContext.HttpContext.Request.ServerVariables["HTTP_USER_AGENT"];
            string requestMethod = filterContext.HttpContext.Request.ServerVariables["REQUEST_METHOD"];
            string httpReferer = filterContext.HttpContext.Request.ServerVariables["HTTP_REFERER"];
            int statusCode = filterContext.HttpContext.Response.StatusCode;

            logger.Debug("{0} {1} {2} {3} \"{4} {5} {6}\" {7} {8} \"{9}\" {10}",
                remoteAddr, "-", string.IsNullOrEmpty(remoteUser) ? "-" : remoteUser, timestamp, requestMethod, url, serverProtocol, statusCode, "-", httpReferer, httpUserAgent);
        }
    }
}