using MVC5Template.Extensions;
using MVC5Template.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample
{
    public class ExceptionController : SupportContoller
    {
        // GET: Sample/Exception
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sample/
        public ActionResult Exception()
        {
            throw new Exception();
        }
    }
}