using MVC5Template.Extensions;
using System.Web.Mvc;

namespace MVC5Template.Areas.Site.Controllers
{
    public class HomeController : SupportContoller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}