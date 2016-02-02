using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.Helpers
{
    public static class SampleHelper
    {
        public static IHtmlString Test()
        {
            return MvcHtmlString.Create(
                string.Format(""));            
        }
    }
}