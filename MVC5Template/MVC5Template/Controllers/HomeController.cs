﻿using System.Web.Mvc;
using MVC5Template.Extensions;

namespace MVC5Template.Areas.Site.Controllers
{
    public class HomeController : SupportContoller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}