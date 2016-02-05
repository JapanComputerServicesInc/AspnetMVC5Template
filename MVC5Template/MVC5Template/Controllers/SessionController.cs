using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Controllers
{
    public class SessionController : DefaultController
    {
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }
    }
}