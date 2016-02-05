using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class PluginController : Controller
    {
        // GET: Plugin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Handsontable()
        {
            return View();
        }

        public new ActionResult Session()
        {
            return View();
        }

        public ActionResult ImageGallery()
        {
            return View();
        }

        public ActionResult FileUpload()
        {
            return View();
        }
    }
}