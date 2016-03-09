using System.Web.Mvc;
using NLog;
using MVC5Template.Filters;

namespace MVC5Template.Extensions
{
    [Logging]
    [LoggingError]
    public class SupportContoller : Controller
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected SupportContoller() : base()
        {

        }
        protected SupportContoller(string name) : base()
        {
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