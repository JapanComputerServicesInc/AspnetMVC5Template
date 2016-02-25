using System.Web.Mvc;
using NLog;
using MVC5Template.Filters;

namespace MVC5Template.Extension
{
    [Logging]
    [LoggingError]
    public class SupportContoller : Controller
    {
        protected static Logger logger;

        protected SupportContoller() : base()
        {

        }
        protected SupportContoller(string name) : base()
        {
            logger = LogManager.GetLogger(name);
        }

        protected string ContllorName
        {
            get { return this.RouteData.Values["controller"].ToString(); }
        }

        protected string ActionName
        {
            get { return this.RouteData.Values["action"].ToString(); }
        }
    }
}