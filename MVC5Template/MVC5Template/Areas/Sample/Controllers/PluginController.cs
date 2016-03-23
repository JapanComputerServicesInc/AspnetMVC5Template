using MVC5Template.Extensions;
using System.IO;
using System.Web.Mvc;

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
            string mapPath = Server.MapPath("/");
            string imageDir = mapPath + "/Content/Images/";
            string[] files = Directory.GetFiles(imageDir, "*.jpg", System.IO.SearchOption.AllDirectories);
            for(int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                file = file.Replace(mapPath, "");
                files[i] = file;
            }
            return View(files);
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