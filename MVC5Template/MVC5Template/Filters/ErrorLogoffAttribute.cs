using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Template.Filters
{
    public class ErrorLogoffAttribute : FilterAttribute, IExceptionFilter
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            FormsAuthentication.SignOut();
            filterContext.HttpContext.Session.Clear();
        }
    }
}