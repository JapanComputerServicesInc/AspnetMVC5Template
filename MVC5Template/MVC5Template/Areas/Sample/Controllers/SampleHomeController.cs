using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class SampleHomeController : Controller
    {
        // GET: Sample/SampleHome
        public ActionResult Index()
        {
            return View();
        }
    }
}