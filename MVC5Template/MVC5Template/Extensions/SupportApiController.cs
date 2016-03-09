using System.Web.Http;
using MVC5Template.Filters;
using NLog;

namespace MVC5Template.Extensions
{
    [Logging]
    [LoggingError]
    public class SupportApiController : ApiController
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
