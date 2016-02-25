using System.Web.Mvc;

namespace MVC5Template.Extension
{
    public class DefaultController : Controller
    {
        // GET: Site/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}