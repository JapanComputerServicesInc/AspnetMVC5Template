using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Template.Models;

namespace MVC5Template.Controllers
{
    public class AccountController : DefaultController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            IEnumerable<User> result = DapperManager.Select<User>("MVC5TemplateServer",
                "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                new { UserID = model.UserID, Password = model.Password });
            if (result.Count() != 0)
            {
                FormsAuthentication.SetAuthCookie(model.UserID, false);
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

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.Redirect("/");
        }
    }
}