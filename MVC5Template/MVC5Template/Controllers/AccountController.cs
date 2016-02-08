using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Template.Models;
using System.Web.SessionState;

namespace MVC5Template.Controllers
{
    public class AccountController : DefaultController
    {
        public AccountController() : base("AccountController")
        {
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            logger.Debug("Test");
            IEnumerable<User> result = DapperManager.Select<User>("MVC5TemplateServer",
                "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                new { UserID = model.UserID, Password = model.Password });
            if (result.Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserID, false);
                //FormsAuthentication.SetAuthCookie(model.UserID, false);
                return this.Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(
                    "Login_Error", HttpContext.GetGlobalResourceObject("ResourceError", "Login_LoginError_ErrorMessage").ToString());
                return View(model);
            }
        }

        //
        // POST: /User/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.Redirect("/");
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<User> result = DapperManager.Select<User>("MVC5TemplateServer",
                "SELECT * FROM [dbo].[User]");

            return View(result);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}