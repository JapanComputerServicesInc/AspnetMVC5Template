using System;
using System.Web;
using System.Web.Mvc;
using NLog;
using MVC5Template.Filters;

namespace MVC5Template.Controllers
{
    [Logging]
    [LoggingError]
    public class DefaultController : Controller
    {
        protected static Logger logger;

        protected DefaultController() : base()
        {

        }
        protected DefaultController(string name) : base()
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