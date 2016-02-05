using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class PluginController : Controller
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
    }
}