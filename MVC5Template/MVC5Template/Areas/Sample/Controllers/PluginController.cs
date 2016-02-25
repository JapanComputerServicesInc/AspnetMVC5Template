using System.Web.Mvc;
using MVC5Template.Extension;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class PluginController : SupportContoller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Handsontable()
        {
            return View();
        }

        [HttpGet]
        public new ActionResult Session()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ImageGallery()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calendar()
        {
            return View();
        }
    }
}