﻿using System.Web.Mvc;
using MVC5Template.Extensions;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class JsonSampleController : SupportContoller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
    }
}