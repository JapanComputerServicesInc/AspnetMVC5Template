using MVC5Template.Filters;
using NLog;
using System.Web.Http;

namespace MVC5Template.Extensions
{
    [Logging]
    [LoggingError]
    public class SupportApiController : ApiController
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
