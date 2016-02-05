using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class PluginController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Handsontable()
        {
            return View();
        }

        [HttpPost]
        public new ActionResult Session()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload()
        {
            return View();
        }
    }
}