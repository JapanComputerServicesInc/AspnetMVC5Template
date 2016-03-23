using MVC5Template.Dapper;
using MVC5Template.Extensions;
using MVC5Template.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Template.Controllers
{
    public class AccountController : SupportContoller
    {
        public AccountController() : base("AccountController")
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<User> result = DapperManager.Query<User>("MVC5TemplateServer",
                    "SELECT UserID, FamilyName, FirstName FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                    new { UserID = model.UserID, Password = model.Password });
                if (result.Count() != 0)
                {
                    Session.Add("UserInfo", result.First());
                    FormsAuthentication.RedirectFromLoginPage(model.UserID, false);
                    //FormsAuthentication.SetAuthCookie(model.UserID, false);
                    //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")) return this.Redirect(returnUrl);
                    return RedirectToAction(string.Empty, "Home");
                }
                else
                {
                    ModelState.AddModelError(
                        "Login_Error", HttpContext.GetGlobalResourceObject("ResourceError", "Login_LoginError_ErrorMessage").ToString());
                }
            }
            return View(model);
        }

        //
        // POST: /User/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return this.Redirect("/");
        }
    }
}