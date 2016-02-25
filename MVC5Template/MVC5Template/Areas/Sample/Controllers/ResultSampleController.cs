using MVC5Template.Extension;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class ResultSampleController : SupportContoller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RedirectGoogle()
        {
            return Redirect("https://www.google.co.jp/");
        }

        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }

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

        public ActionResult UnAuth()
        {
            return new HttpUnauthorizedResult();
        }

        public ActionResult Empty()
        {
            return new EmptyResult();
        }

        public ActionResult HelloWorld()
        {
            return Content("Hello World!", MediaTypeNames.Text.Plain);
        }

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