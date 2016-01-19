using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Template.Models;
using System.Threading.Tasks;

namespace MVC5Template.Controllers
{        // このコントローラは認証いらない
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ReturnUrl = "/Account/Login";
            return View();
        }

        // GET: Login
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                DapperSample<User> dapper = new DapperSample<User>("MVC5TemplateServer");
                List<User> result = await dapper.Select("SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password"
                    , new { UserID = model.UserName, Password = model.Password });
                if (result.Count != 0)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "ユーザー名またはパスワードが無効です。");
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
        }
    }
}