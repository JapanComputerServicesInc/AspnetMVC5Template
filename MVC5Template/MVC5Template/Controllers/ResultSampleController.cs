using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class ResultSampleController : DefaultController
    {
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RedirectGoogle()
        {
            return Redirect("https://www.google.co.jp/");
        }

        [HttpPost]
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult HttpStatus(int code)
        {
            // 抜粋
            switch (code)
            {
                case (int)HttpStatusCode.OK: return new HttpStatusCodeResult(HttpStatusCode.OK);
                case (int)HttpStatusCode.Created: return new HttpStatusCodeResult(HttpStatusCode.Created);
                case (int)HttpStatusCode.MovedPermanently: return new HttpStatusCodeResult(HttpStatusCode.MovedPermanently);
                case (int)HttpStatusCode.Found: return new HttpStatusCodeResult(HttpStatusCode.Found);
                case (int)HttpStatusCode.SeeOther: return new HttpStatusCodeResult(HttpStatusCode.SeeOther);
                case (int)HttpStatusCode.BadRequest: return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                case (int)HttpStatusCode.Unauthorized: return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                case (int)HttpStatusCode.Forbidden: return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                case (int)HttpStatusCode.NotFound: return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                case (int)HttpStatusCode.MethodNotAllowed: return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
                case (int)HttpStatusCode.InternalServerError: return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                default: return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult UnAuth()
        {
            return new HttpUnauthorizedResult();
        }

        [HttpPost]
        public ActionResult Empty()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult HelloWorld()
        {
            return Content("Hello World!", MediaTypeNames.Text.Plain);
        }

        [HttpPost]
        public ActionResult Download()
        {
            var path = Server.MapPath("~/App_Data/TextFile1.txt");
            if (System.IO.File.Exists(path))
            {
                return File(path, MediaTypeNames.Application.Octet, "download.txt");
            }
            return HttpNotFound("File does not exist.");
        }
    }
}