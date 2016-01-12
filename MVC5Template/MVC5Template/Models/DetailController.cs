using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Models
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index()
        {
            return View();
        }

        // GET: User
        public ActionResult UserDetil()
        {
            User model = new User();
            model.ID = "00001";
            model.Name = "テスト太郎";
            return View(model);
        }
    }
}