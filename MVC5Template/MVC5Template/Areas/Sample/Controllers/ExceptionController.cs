using MVC5Template.Extensions;
using System;
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