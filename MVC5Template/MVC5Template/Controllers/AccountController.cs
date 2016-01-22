using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC5Template.Models;

namespace MVC5Template.Controllers
{
    public class AccountController : DefaultController
    {
        public ActionResult Index()
        {
            //ViewBag.ReturnUrl = "/Account/Login";
            return View("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<User> result = DapperManager.Select<User>("MVC5TemplateServer",
                    "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                    new { UserID = model.UserID, Password = model.Password });
                if (result.Count() != 0)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError(
                        "Login_Error", 
                        HttpContext.GetGlobalResourceObject("ResourceError", "Login_LoginError_ErrorMessage").ToString());
                    return View();
                }

                //var userManager = new ApplicationUserManager(new ApplicationUserStore());
                //userManager.PasswordHasher = new PasswordHasher();

                //var user = await userManager.FindAsync(model.UserName, model.Password);
                //if (user != null)
                //{
                //    var authentication = this.HttpContext.GetOwinContext().Authentication;
                //    var identify = await userManager.CreateIdentityAsync(
                //        user,
                //        DefaultAuthenticationTypes.ApplicationCookie);
                //    authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                //    authentication.SignIn(new AuthenticationProperties() { IsPersistent = false }, identify);

                //    return Redirect(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError("", "ログインIDまたはパスワードが無効です。");
                //}
            }
            return View();
        }
    }
}