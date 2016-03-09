using MVC5Template.Extensions;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class SampleHomeController : SupportContoller
    {
        // GET: Sample/SampleHome
        public ActionResult Index()
        {
            return View();
        }
    }
}