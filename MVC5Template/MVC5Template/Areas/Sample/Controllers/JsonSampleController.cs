using MVC5Template.Extensions;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class JsonSampleController : SupportContoller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
    }
}