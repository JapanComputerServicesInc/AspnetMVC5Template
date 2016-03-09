using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Template.Extensions;

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