using MVC5Template.Extensions;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class FormsAuthenticationController : SupportContoller
    {
        // GET: FormsAuthentication
        public ActionResult Index()
        {
            return View();
        }
    }
}