using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class HomeController : Controller
    {
        public string GetCookieValue(string key)
        {
            return Request.Cookies[key].Value;
        }

        public void SetCookieValue(string key, string value, DateTime expires, bool httpOnly)
        {
            Response.AppendCookie(new HttpCookie(key)
            {
                Value = value,
                Expires = expires,
                HttpOnly = httpOnly
            });
        }

        public object GetSessionValue(string key)
        {
            return Session[key];
        }

        public void SetSessionValue(string key, object value)
        {
            Session[key] = value;
        }

        public void RemoveSessionValue(string key)
        {
            Session.Remove(key);
        }

        public void SetTempData(string key, object value)
        {
            TempData[key] = value;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}