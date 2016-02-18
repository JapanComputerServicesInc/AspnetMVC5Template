using System.Web.Http;
using MVC5Template.Filters;

namespace MVC5Template.Controllers
{
    [Logging]
    [LoggingError]
    public class DefaultApiController : ApiController
    {
    }
}
